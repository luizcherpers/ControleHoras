using Application.Application.Core.Commands.Projetos;
using Application.Application.Core.Queries.Projetos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Application.AppControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjetoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new ProjetoGetByIdRequest( id ));

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new ProjetoGetAllRequest());

            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjetoCreateCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProjetoUpdateCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        
    }
}
