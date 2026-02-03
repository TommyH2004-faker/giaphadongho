using GiaPha_Domain.Entities;

namespace GiaPha_Application.Repository
{
    public interface INotificationRepository
    {
        Task AddAsync(Notification notification);
        Task<IReadOnlyList<Notification>> GetAllForUserAsync(Guid userId, Guid? chiHoId, Guid? hoId);
        Task<IReadOnlyList<Notification>> GetAllForAdminAsync();
        Task MarkAsReadAsync(Guid notificationId);
        Task<IReadOnlyList<Notification>> GetByChiHoIdAsync(Guid chiHoId);
    }
}