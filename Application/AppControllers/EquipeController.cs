
using Application.Appliaction.Domain.Contantes;
using Application.Appliaction.Domain.Interfaces;
using Application.Application.Core.Commands.Equipes;
using Application.Application.Core.Queries.Equipes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.AppControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EquipeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IVerificarPerfilGestor _verificarPerfilGestor;

        public EquipeController(IMediator mediator, IVerificarPerfilGestor verificarPerfilGestor)
        {
            _mediator = mediator;
            _verificarPerfilGestor = verificarPerfilGestor;
        }

        [HttpGet]
        public async Task<IActionResult> GetEquipes()
        {
            if (!_verificarPerfilGestor.TemPerfilGestor())
            {
                return BadRequest(ConstantesMessages.PERFIL_NAO_PERMITIDO);
            }

            var response = await _mediator.Send(new EquipeRequest());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EquipeCreateCommand command)
        {

            if (!_verificarPerfilGestor.TemPerfilGestor())
            {
                return BadRequest(ConstantesMessages.PERFIL_NAO_PERMITIDO);
            }

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EquipeUpdateCommand command)
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
