using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Interfaces;
using Application.Appliaction.Domain.Interfaces.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Queries.Colaboradores
{
    public class AutenticacaoHandler : IQueryHandler<AutenticacaoRequest, AutenticacaoResult>
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IConfiguration _configuration;

        public AutenticacaoHandler(
            IColaboradorRepository colaboradorRepository,
            IConfiguration configuration)
        {
            _colaboradorRepository = colaboradorRepository;
            _configuration = configuration;
        }


        public async Task<AutenticacaoResult> Handle(AutenticacaoRequest request, CancellationToken cancellationToken)
        {
            var senha = Convert.ToBase64String(Encoding.ASCII.GetBytes(request.Senha));
            var colaborador = await _colaboradorRepository.GetByEmailSenha(request.Email, senha);

            if (colaborador == null)
            {
                return new AutenticacaoResult("", "Usuário não encontrado!");
            }

            return new AutenticacaoResult(GerarToken(colaborador), "Token gerado com sucesso!");
        }

        private string GerarToken(Colaborador colaborador)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name, colaborador.Nome),
                new Claim(ClaimTypes.Email, colaborador.Email),
                new Claim("Perfil", colaborador.Perfil.PerfilEnum.ToString()),
                new Claim(ClaimTypes.NameIdentifier, colaborador.Id.ToString())

            };

            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: "Controle de horas",
                    audience: "Controle de horas",
                    claims: claims,
                    expires : DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
