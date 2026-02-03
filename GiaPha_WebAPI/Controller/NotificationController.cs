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

        // ✅ Lấy thông báo của user đang đăng nhập
        [HttpGet("my")]
        public async Task<IActionResult> GetMyNotifications()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                      ?? User.FindFirstValue("sub");
            var role = User.FindFirstValue(ClaimTypes.Role)
                      ?? User.FindFirstValue("role");

            if (userId == null)
                return Unauthorized();

            var userGuid = Guid.Parse(userId);

            // Nếu là ADMIN → thấy tất cả
            if (role == "ADMIN")
            {
                var allNotifications = await _notificationRepository.GetAllForAdminAsync();
                return Ok(allNotifications);
            }

            // Lấy ChiHoId và HoId từ user
            var user = await _context.TaiKhoanNguoiDungs
                .Include(u => u.ChiHo)
                .FirstOrDefaultAsync(u => u.Id == userGuid);
                
            if (user == null)
                return Unauthorized();

            Guid? chiHoId = user.ChiHoId;
            Guid? hoId = user.ChiHo?.IdHo;

            // User thường → thấy: global + cá nhân + chi họ + toàn bộ Họ
            var notifications = await _notificationRepository
                .GetAllForUserAsync(userGuid, chiHoId, hoId);

            return Ok(notifications);
        }

        // ✅ Đánh dấu đã đọc
        [HttpPut("read/{notificationId}")]
        public async Task<IActionResult> MarkAsRead(Guid notificationId)
        {
            await _notificationRepository.MarkAsReadAsync(notificationId);
            return NoContent();
        }

        // ✅ Thông báo theo chi họ
        [HttpGet("chiho/{chiHoId}")]
        public async Task<IActionResult> GetNotificationsByChiHo(Guid chiHoId)
        {
            var notifications =
                await _notificationRepository.GetByChiHoIdAsync(chiHoId);

            if (!notifications.Any())
                return NotFound("Chưa có thông báo nào cho chi họ này.");

            return Ok(notifications);
        }
    }
}
