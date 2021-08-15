using Application.Application.Core.Commands.Colaboradores;
using Application.Application.Core.Queries.Colaboradores;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.AppControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ColaboradorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new ColaboradorAllRequest());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ColaboradorCreateCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ColaboradorUpdateCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
