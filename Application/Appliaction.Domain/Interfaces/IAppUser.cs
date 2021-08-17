using Application.Appliaction.Domain.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Appliaction.Domain.Interfaces
{
    public interface IAppUser
    {
        Guid GetUserId();
        PerfilEnum GetUserPerfil();
        bool IsAuthenticated();
    }
}
