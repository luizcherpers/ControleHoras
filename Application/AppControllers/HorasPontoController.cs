using Application.Appliaction.Domain.Interfaces;
using Application.Application.Core.Commands.HorasTrabalhadas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.AppControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HorasPontoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAppUser _appUser;

        public HorasPontoController(IMediator mediator, IAppUser appUser )
        {
            _mediator = mediator;
            _appUser = appUser;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistrarCreateCommand command)
        {
            command.ColaboradorId = _appUser.GetUserId();
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RegistrarUpdateCommand command)
        {
            command.ColaboradorId = _appUser.GetUserId();
            var response = await _mediator.Send(command);

            return Ok(response);
        }

    }
}
