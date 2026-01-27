using GiaPha_Application.Features.ChiHo.Command.CreateChiHo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static GiaPha_WebAPI.Controller.ControllerChiHo.RequestChiHo;

namespace GiaPha_WebAPI.Controller.ControllerChiHo;
    [ApiController]
    [Route("api/[controller]")]
    public class ChiHoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ChiHoController(IMediator mediator)
        {
            _mediator = mediator;
        }
    [HttpPost]
    public async Task<IActionResult> CreateChiHo([FromBody] CreateChiHoRequest request)
    {
        var command = new CreateChiHoCommand
        {
            IdHo = request.IdHo,
            TenChiHo = request.TenChiHo,
            MoTa = request.MoTa
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        

 
}