using GiaPha_Application.Repository;
using GiaPha_Domain.Entities;
using GiaPha_Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace GiaPha_Infrastructure.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly DbGiaPha _context;
        public NotificationRepository(DbGiaPha context) => _context = context;

        public async Task AddAsync(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Notification>> GetAllForUserAsync(Guid userId, Guid? chiHoId, Guid? hoId)
        {
            // Logic:
            // 1. IsGlobal = true → TẤT CẢ thấy
            // 2. NguoiNhanId = userId → Cá nhân
            // 3. ChiHoId = chiHoId của user → Chi Họ cụ thể
            // 4. HoId = hoId của user → TẤT CẢ thuộc Họ đó thấy
            
            return await _context.Notifications
                .Where(n => n.IsGlobal 
                         || n.NguoiNhanId == userId 
                         || (chiHoId.HasValue && n.ChiHoId.HasValue && n.ChiHoId == chiHoId.Value)
                         || (hoId.HasValue && n.HoId.HasValue && n.HoId == hoId.Value))
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Notification>> GetAllForAdminAsync()
        {
            // Admin thấy tất cả
            return await _context.Notifications
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task MarkAsReadAsync(Guid notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                typeof(Notification).GetProperty("DaDoc")?.SetValue(notification, true);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IReadOnlyList<Notification>> GetByChiHoIdAsync(Guid chiHoId)
        {
            return await _context.Notifications
                .Where(n => n.ChiHoId == chiHoId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }
    }
}