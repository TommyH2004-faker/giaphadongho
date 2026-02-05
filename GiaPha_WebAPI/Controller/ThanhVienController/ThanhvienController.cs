using GiaPha_Application.Features.ThanhVien.Command.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GiaPha_WebAPI.Controller.ThanhVienController;
[ApiController]
[Route("api/[controller]")]
public class ThanhVienController : ControllerBase
{
    private readonly IMediator _mediator;
    public ThanhVienController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateThanhVienCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result.Data);
    }
}