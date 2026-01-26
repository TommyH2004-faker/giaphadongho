
using GiaPha_Domain.Entities;
using GiaPha_Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
namespace GiaPha_Infrastructure.Db
{
    public class DbGiaPha : DbContext
    {
        public DbGiaPha(DbContextOptions<DbGiaPha> options) : base(options)
        {
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

    }
}