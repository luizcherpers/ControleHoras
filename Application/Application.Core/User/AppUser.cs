using Application.Appliaction.Domain.Enumerados;
using Application.Appliaction.Domain.Interfaces;
using Application.Application.Core.Extension;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Application.Core.User
{
    public class AppUser : IAppUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AppUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public PerfilEnum GetUserPerfil()
        {
            var perfil = _accessor.HttpContext.User.GetPerfilUser();

            PerfilEnum perfilEnum;

            if (!Enum.TryParse<PerfilEnum>(perfil, out perfilEnum))
            {
                perfilEnum = default;
            }

            return perfilEnum;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
