
using Application.Application.Core.Commands.Equipes;
using Application.Application.Core.Queries.Equipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.AppControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EquipeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEquipes()
        {
            var response = await _mediator.Send(new EquipeRequest());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EquipeCreateCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EquipeUpdateCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }


    }
}
