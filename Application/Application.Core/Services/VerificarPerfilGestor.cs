using Application.Appliaction.Domain.Enumerados;
using Application.Appliaction.Domain.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Application.Core.Services
{
    public class VerificarPerfilGestor : IVerificarPerfilGestor
    {
         private string AuthToken { get; set; }
 
        public IVerificarPerfilGestor SetToken(string token)
        {
            AuthToken = token;
            return this;
        }

        public bool TemPerfilGestor()
        {
            var handler = new JwtSecurityTokenHandler();

            string separator = " ";

            int separatorIndex = AuthToken.IndexOf(separator);

            string resultToken = AuthToken.Substring(separatorIndex + separator.Length);

            var handlerToken = handler.ReadToken(resultToken) as JwtSecurityToken;

            var perfil = handlerToken.Claims.First(claim => claim.Type == "Perfil").Value;

            PerfilEnum perfilEnum ;

            if(!Enum.TryParse<PerfilEnum>(perfil, out perfilEnum))
            {
                perfilEnum = default;
            }

            return perfilEnum == PerfilEnum.Gestor;            
        }
    }
}