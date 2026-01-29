
using GiaPha_Domain.Common;
using GiaPha_Domain.Entities;
using GiaPha_Infrastructure.Configuration;
using GiaPha_Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
namespace GiaPha_Infrastructure.Db
{
    public class DbGiaPha : DbContext
    {
        private readonly IDomainEventDispatcher _eventDispatcher;
        public DbGiaPha(DbContextOptions<DbGiaPha> options, IDomainEventDispatcher eventDispatcher) : base(options)
        {
            _eventDispatcher = eventDispatcher;
        }
    public DbSet<Album> Albums { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<ChiHo> ChiHos { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Ho> Hos { get; set; }
    public DbSet<HonNhan> HonNhans { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<QuanHeChaCon> QuanHeChaCons { get; set; }
    public DbSet<SuKien> SuKiens { get; set; }
    public DbSet<TaiKhoanNguoiDung> TaiKhoanNguoiDungs { get; set; }
    public DbSet<TepTin> TepTins { get; set; }
    public DbSet<ThanhTuu> ThanhTuu { get; set; }
    public DbSet<ThanhVien> ThanhViens { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration( new AlbumConfiguration());
            modelBuilder.ApplyConfiguration( new AuditLogConfiguration());
            modelBuilder.ApplyConfiguration( new ChiHoConfiguration());
            modelBuilder.ApplyConfiguration( new CommentConfiguration());
            modelBuilder.ApplyConfiguration( new HoConfiguration());
            modelBuilder.ApplyConfiguration( new HonNhanConfiguration());
            modelBuilder.ApplyConfiguration( new NotificationConfiguration());
            modelBuilder.ApplyConfiguration( new QuanHeChaConConfiguration());
            modelBuilder.ApplyConfiguration( new SuKienConfiguration());
            modelBuilder.ApplyConfiguration( new TaiKhoanNguoiDungConfiguration());
            modelBuilder.ApplyConfiguration( new TepTinConfiguration());
            modelBuilder.ApplyConfiguration( new ThanhTuuConfiguration());
            modelBuilder.ApplyConfiguration( new ThanhVienConfiguration());
        }
     public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // 1. Lấy tất cả entities có Domain Events
            var entitiesWithEvents = ChangeTracker.Entries<IHasDomainEvents>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity)
                .ToList();

            // 2. Lấy tất cả Domain Events trước khi save
            //  Nếu entity mới (Added), IdOrder vẫn = 0 tại thời điểm này
            var domainEvents = entitiesWithEvents
                .SelectMany(e => e.DomainEvents)
                .ToList();

            // 3. Clear events khỏi entities (tránh dispatch lại)
            entitiesWithEvents.ForEach(e => e.ClearDomainEvents());

            // 4. Lưu changes vào database TRƯỚC
            //  Sau bước này, IdOrder đã được generate từ DB
            var result = await base.SaveChangesAsync(cancellationToken);

            // 5. Dispatch events qua DomainEventDispatcher (tự động tìm wrapper)
            //  Tại thời điểm này, IdOrder đã có giá trị thật từ DB
            await _eventDispatcher.DispatchAllAsync(domainEvents, cancellationToken);
            return result;
        }
    }
}