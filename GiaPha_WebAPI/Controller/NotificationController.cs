// using GiaPha_Application.Repository;
// using Microsoft.AspNetCore.Mvc;

// namespace GiaPha_WebAPI.Controller
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class NotificationController : ControllerBase
//     {
//         private readonly INotificationRepository _notificationRepository;
//         public NotificationController(INotificationRepository notificationRepository)
//         {
//             _notificationRepository = notificationRepository;
//         }

//         [HttpGet("{userId}")]
//         public async Task<IActionResult> GetNotifications(Guid userId)
//         {
//             var notifications = await _notificationRepository.GetAllForUserAsync(userId);
//             return Ok(notifications);
//         }

//         [HttpPost("read/{notificationId}")]
//         public async Task<IActionResult> MarkAsRead(Guid notificationId)
//         {
//             await _notificationRepository.MarkAsReadAsync(notificationId);
//             return NoContent();
//         }
//         [HttpGet("chiho/{chiHoId}")]
//         public async Task<IActionResult> GetNotificationsByChiHo(Guid chiHoId)
//         {
//             var notifications = await _notificationRepository.GetByChiHoIdAsync(chiHoId);
//             if (notifications == null || !notifications.Any())
//                 return NotFound("Chưa có thông báo nào cho chi họ này.");

//             return Ok(notifications);
//         }
//     }
// }
using GiaPha_Application.Repository;
using GiaPha_Infrastructure.Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GiaPha_WebAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly DbGiaPha _context;

        public NotificationController(
            INotificationRepository notificationRepository,
            DbGiaPha context)
        {
            _notificationRepository = notificationRepository;
            _context = context;
        }
    }
}
