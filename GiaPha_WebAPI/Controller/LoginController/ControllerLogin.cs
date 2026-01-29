using GiaPha_Application.Features.Auth.Command.Activate;
using GiaPha_Application.Features.Auth.Command.Changepassword.ChangePasswordCommand;
using GiaPha_Application.Features.Auth.Command.ForgetPassword;
using GiaPha_Application.Features.Auth.Command.Login;
using GiaPha_Application.Features.Auth.Command.Register;
using GiaPha_WebAPI.Controller.LoginController;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using static GiaPha_WebAPI.Controller.LoginController.LoginRequest;

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
    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand request)
    {
        var command = new RegisterCommand
        {
            TenDangNhap = request.TenDangNhap,
            Email = request.Email,
            MatKhau = request.MatKhau,
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
    [HttpPost("/changepassword")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var command = new ChangePasswordCommand
        {
            UserId = request.UserId,
            CurrentPassword = request.CurrentPassword,
            NewPassword = request.NewPassword,
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
    [HttpPost("/activate")]
    public async Task<IActionResult> Activate([FromBody] ActivateUserRequest request)
    {
        var command = new ActivateUserCommand
        {
            UserId = request.UserId,
            ActivationCode = request.ActivationCode,
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
    [HttpPost("/forgetpassword")]
    public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest request)
    {
        var command = new ForgetPasswordCommand
        {
            Email = request.Email,
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}   