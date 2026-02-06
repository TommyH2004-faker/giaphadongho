
using GiaPha_Application.Repository;
using GiaPha_Domain.Common;
using GiaPha_Domain.Entities;
using GiaPha_Infrastructure.Configuration;
using GiaPha_Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GiaPha_Infrastructure.Db
{
    public class DbGiaPha : DbContext , IUnitOfWork
    {
        private readonly IDomainEventDispatcher _eventDispatcher;
        private readonly ILogger<DbGiaPha> _logger;
        
        public DbGiaPha(DbContextOptions<DbGiaPha> options, IDomainEventDispatcher eventDispatcher, ILogger<DbGiaPha> logger) : base(options)
        {
            _eventDispatcher = eventDispatcher;
            _logger = logger;
        }

    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<ChiHo> ChiHos { get; set; }
    public DbSet<Ho> Hos { get; set; }
    public DbSet<MoPhan> MoPhans { get; set; }
    public DbSet<HonNhan> HonNhans { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<QuanHeChaCon> QuanHeChaCons { get; set; }
    public DbSet<SuKien> SuKiens { get; set; }
    public DbSet<TaiKhoanNguoiDung> TaiKhoanNguoiDungs { get; set; }
    public DbSet<TepTin> TepTins { get; set; }
    public DbSet<ThanhTuu> ThanhTuus { get; set; }
    public DbSet<ThanhVien> ThanhViens { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
            modelBuilder.ApplyConfiguration(new AuditLogConfiguration());
            modelBuilder.ApplyConfiguration(new ChiHoConfiguration());
            modelBuilder.ApplyConfiguration(new MoPhanConfiguration());
            modelBuilder.ApplyConfiguration(new HoConfiguration());
            modelBuilder.ApplyConfiguration(new HonNhanConfiguration());

            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new QuanHeChaConConfiguration());
            modelBuilder.ApplyConfiguration(new SuKienConfiguration());
            modelBuilder.ApplyConfiguration(new TaiKhoanNguoiDungConfiguration());
            modelBuilder.ApplyConfiguration(new TepTinConfiguration());
            modelBuilder.ApplyConfiguration(new ThanhTuuConfiguration());
            modelBuilder.ApplyConfiguration(new ThanhVienConfiguration());
        
        }
    //  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //     {
    //         // 1. Lấy tất cả entities có Domain Events
    //         var entitiesWithEvents = ChangeTracker.Entries<IHasDomainEvents>()
    //             .Where(e => e.Entity.DomainEvents.Any())
    //             .Select(e => e.Entity)
    //             .ToList();

    //         // 2. Lấy tất cả Domain Events trước khi save
    //         //  Nếu entity mới (Added), IdOrder vẫn = 0 tại thời điểm này
    //         var domainEvents = entitiesWithEvents
    //             .SelectMany(e => e.DomainEvents)
    //             .ToList();

    //         // 3. Clear events khỏi entities (tránh dispatch lại)
    //         entitiesWithEvents.ForEach(e => e.ClearDomainEvents());

    //         // 4. Lưu changes vào database TRƯỚC
    //         //  Sau bước này, IdOrder đã được generate từ DB
    //         var result = await base.SaveChangesAsync(cancellationToken);

    //         // 5. Dispatch events qua DomainEventDispatcher (tự động tìm wrapper)
    //         //  Tại thời điểm này, IdOrder đã có giá trị thật từ DB
    //         await _eventDispatcher.DispatchAllAsync(domainEvents, cancellationToken);
    //         return result;
    //     }

        public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            _logger.LogInformation("🔵 [DbGiaPha] SaveChangesAsync() được gọi");
            
            // 1. Lấy tất cả entities có Domain Events
            var entitiesWithEvents = ChangeTracker.Entries<IHasDomainEvents>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity)
                .ToList();

            _logger.LogInformation("📦 [DbGiaPha] Tìm thấy {Count} entities có events", entitiesWithEvents.Count);
            
            // 2. Lấy tất cả Domain Events trước khi save
            var domainEvents = entitiesWithEvents
                .SelectMany(e => e.DomainEvents)
                .ToList();

            _logger.LogInformation("⚡ [DbGiaPha] Tổng cộng {Count} domain events sẽ được dispatch", domainEvents.Count);
            foreach (var evt in domainEvents)
            {
                _logger.LogInformation("   - Event: {EventType}", evt.GetType().Name);
            }

            // 3. Clear events khỏi entities (tránh dispatch lại)
            entitiesWithEvents.ForEach(e => e.ClearDomainEvents());

            // 4. Lưu changes vào database TRƯỚC
            var result = await base.SaveChangesAsync(ct);
            _logger.LogInformation("💾 [DbGiaPha] Đã lưu {Count} changes vào database", result);

            // 5. Dispatch events qua DomainEventDispatcher
            if (domainEvents.Any())
            {
                _logger.LogInformation("📤 [DbGiaPha] Bắt đầu dispatch {Count} events...", domainEvents.Count);
                await _eventDispatcher.DispatchAllAsync(domainEvents, ct);
                _logger.LogInformation("✅ [DbGiaPha] Đã dispatch xong tất cả events");
            }
            else
            {
                _logger.LogWarning("⚠️ [DbGiaPha] KHÔNG có events nào để dispatch!");
            }
            
            return result;
        }
    }

}