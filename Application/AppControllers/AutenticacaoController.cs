using Application.Application.Core.Queries.Colaboradores;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.AppControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutenticacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(AutenticacaoRequest request)
        {
            var respose = await _mediator.Send(request);

            return Ok(respose);
        }

    }
}
