using GiaPha_Application.Features.Auth.Command.Login;
using GiaPha_WebAPI.Controller.LoginController;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;

namespace GiaPha_WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class ControllerLogin : ControllerBase
{
    private readonly IMediator _mediator;

    public ControllerLogin(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
       var command = new LoginCommand
        {
            TenDangNhap = request.TenDangNhap,
            MatKhau = request.MatKhau,
        };

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return Unauthorized(result);

        return Ok(result);
    }
}
