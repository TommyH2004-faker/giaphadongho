using GiaPha_Application.Features.GiaPha.Queries.GetGiaPhaTree;
using GiaPha_Application.Features.GiaPha.Queries.GetMyGiaPhaTree;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GiaPha_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GiaPhaController : ControllerBase
{
    private readonly IMediator _mediator;

    public GiaPhaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Lấy gia phả của user hiện tại (yêu cầu đăng nhập)
    /// </summary>
    [Authorize]
    [HttpGet("my-tree")]
    public async Task<IActionResult> GetMyGiaPhaTree(
        [FromQuery] int maxLevel = 10,
        [FromQuery] bool includeNuGioi = true)
    {
        // Lấy userId từ JWT token
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
        {
            return Unauthorized(new { message = "Token không hợp lệ" });
        }

        var query = new GetMyGiaPhaTreeQuery
        {
            UserId = userId,
            MaxLevel = maxLevel,
            IncludeNuGioi = includeNuGioi
        };

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            // Nếu user chưa có họ, trả về 404 với message
            if (result.ErrorType == GiaPha_Application.Common.ErrorType.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }

        return Ok(result);
    }

    /// <summary>
    /// Lấy gia phả theo hoId (cho admin hoặc xem gia phả khác)
    /// </summary>
    [HttpGet("{hoId}/tree")]
    public async Task<IActionResult> GetGiaPhaTree(
        Guid hoId, 
        [FromQuery] int maxLevel = 10,
        [FromQuery] bool includeNuGioi = true)
    {
        var query = new GetGiaPhaTreeQuery 
        { 
            HoId = hoId,
            MaxLevel = maxLevel,
            IncludeNuGioi = includeNuGioi
        };
        
        var result = await _mediator.Send(query);
        
        if (!result.IsSuccess)
            return BadRequest(result);
        
        return Ok(result);
    }

}