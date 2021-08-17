using Application.Appliaction.Domain.Enumerados;
using Application.Appliaction.Domain.Interfaces;

namespace Application.Application.Core.Services
{
    public class VerificarPerfilGestor : IVerificarPerfilGestor
    {
        private readonly IAppUser _appUser;
        public VerificarPerfilGestor(IAppUser appUser)
        {
            _appUser = appUser;
        }

        public bool TemPerfilGestor()
        {
            var perfil = _appUser.GetUserPerfil();

           return perfil == PerfilEnum.Gestor;            
        }
    }
}