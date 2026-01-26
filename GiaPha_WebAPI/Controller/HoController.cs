
using GiaPha_Application.DTOs;
using GiaPha_Application.Features.HoName.Command.CreateHo;
using GiaPha_Application.Features.HoName.Command.UpdateHo;
using GiaPha_Application.Features.HoName.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GiaPha_WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class HoController : ControllerBase
{
    private readonly IMediator _mediator;
    public HoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public class CreateHoRequest
    {
        public string TenHo { get; set; } = null!;
        public string? MoTa { get; set; }
    }

    [HttpPost]
    public async Task<IActionResult> CreateHo([FromBody] CreateHoRequest request)
    {
        var command = new CreateHoCommand
        {
            TenHo = request.TenHo,
            MoTa = request.MoTa
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHo(Guid id, [FromBody] UpdateHoCommand request)
    {
        if (id != request.Id)
        {
            return BadRequest("ID in URL does not match ID in request body.");
        }
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHoById(Guid id)
    {
        var query = new GetHoByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}