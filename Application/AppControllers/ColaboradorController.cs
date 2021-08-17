using Application.Appliaction.Domain.Contantes;
using Application.Appliaction.Domain.Interfaces;
using Application.Application.Core.Commands.Colaboradores;
using Application.Application.Core.Queries.Colaboradores;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.AppControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColaboradorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IVerificarPerfilGestor _verificarPerfilGestor;

        public ColaboradorController(IMediator mediator, IVerificarPerfilGestor verificarPerfilGestor)
        {
            _mediator = mediator;
            _verificarPerfilGestor = verificarPerfilGestor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!_verificarPerfilGestor.TemPerfilGestor())
            {
                return BadRequest(ConstantesMessages.PERFIL_NAO_PERMITIDO);
            }

            var response = await _mediator.Send(new ColaboradorAllRequest());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ColaboradorCreateCommand command)
        {
            if (!_verificarPerfilGestor.TemPerfilGestor())
            {
                return BadRequest(ConstantesMessages.PERFIL_NAO_PERMITIDO);
            }

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ColaboradorUpdateCommand command)
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
