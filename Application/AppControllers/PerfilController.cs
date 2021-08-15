using Application.Application.Core.Queries.Perfil;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.AppControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PerfilController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPerfis()
        {
            var response =  await _mediator.Send( new PerfilQueryRequest());

            return Ok(response);
        }
    }

}
