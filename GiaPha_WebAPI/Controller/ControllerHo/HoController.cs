
using GiaPha_Application.Features.HoName.Command.CreateHo;
using GiaPha_Application.Features.HoName.Command.UpdateHo;
using GiaPha_Application.Features.HoName.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static GiaPha_WebAPI.Controller.ControllerHo.RequestHo;

namespace GiaPha_WebAPI.Controller.ControllerHo;

[ApiController]
[Route("api/[controller]")]
public class HoController : ControllerBase
{
    private readonly IMediator _mediator;
    public HoController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateHo([FromBody] CreateHoRequest request)
    {
        var command = new CreateHoCommand
        {
            TenHo = request.TenHo,
            MoTa = request.MoTa,
            queQuan = request.queQuan
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHo(Guid id, [FromBody] UpdateHoRequest request)
    {
        var command = new UpdateHoCommand
        {
            Id = id,
            ThuyToId = request.ThuyToId,
            TenHo = request.TenHo,
            MoTa = request.MoTa
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHoById(Guid id)
    {
        var query = new GetHoByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllHo()
    {
        var query = new GiaPha_Application.Features.HoName.Queries.GetAllHo.GetAllHoQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpGet("top3")]
    public async Task<IActionResult> GetTop3Ho()
    {
        var query = new GetTop3HoQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpPost("{id}/assign-thuy-to/{thuyToId}")]
    public async Task<IActionResult> AssignThuyTo(Guid id,  Guid thuyToId)
    {
        var command = new GiaPha_Application.Features.HoName.Command.AssignThuyTo.AssignThuyToCommand
        {
            HoId = id,
            ThuyToId = thuyToId
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}   