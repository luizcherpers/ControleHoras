using Application.Appliaction.Domain.Contantes;
using Application.Appliaction.Domain.Interfaces;
using Application.Application.Core.Commands.Projetos;
using Application.Application.Core.Queries.Projetos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Application.AppControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjetoController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IVerificarPerfilGestor _verificarPerfilGestor;

        public ProjetoController(IMediator mediator, IVerificarPerfilGestor verificarPerfilGestor)
        {
            _mediator = mediator;
            _verificarPerfilGestor = verificarPerfilGestor;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            if (!_verificarPerfilGestor.TemPerfilGestor())
            {
                return BadRequest(ConstantesMessages.PERFIL_NAO_PERMITIDO);
            }

            var response = await _mediator.Send(new ProjetoGetByIdRequest( id ));

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!_verificarPerfilGestor.TemPerfilGestor())
            {
                return BadRequest(ConstantesMessages.PERFIL_NAO_PERMITIDO);
            }

            var response = await _mediator.Send(new ProjetoGetAllRequest());

            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjetoCreateCommand command)
        {
            if (!_verificarPerfilGestor.TemPerfilGestor())
            {
                return BadRequest(ConstantesMessages.PERFIL_NAO_PERMITIDO);
            }

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProjetoUpdateCommand command)
        {

            if (!_verificarPerfilGestor.TemPerfilGestor())
            {
                return BadRequest(ConstantesMessages.PERFIL_NAO_PERMITIDO);
            }

            var response = await _mediator.Send(command);

            return Ok(response);
        }        
    }
}
