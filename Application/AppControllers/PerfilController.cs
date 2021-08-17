using Application.Appliaction.Domain.Contantes;
using Application.Appliaction.Domain.Interfaces;
using Application.Application.Core.Extension;
using Application.Application.Core.Queries.Perfil;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.AppControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PerfilController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IVerificarPerfilGestor _verificarPerfilGestor;

        public PerfilController(IMediator mediator, IVerificarPerfilGestor verificarPerfilGestor )
        {
            _mediator = mediator;
            _verificarPerfilGestor = verificarPerfilGestor;
        }

        [HttpGet]
        public async Task<IActionResult> GetPerfis()
        {
            if (!_verificarPerfilGestor.TemPerfilGestor())
            {
                return BadRequest(ConstantesMessages.PERFIL_NAO_PERMITIDO);
            }

            var response =  await _mediator.Send( new PerfilQueryRequest());

            return Ok(response);
        }
    }

}
