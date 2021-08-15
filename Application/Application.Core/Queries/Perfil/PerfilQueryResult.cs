using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Application.Core.Queries.Perfil
{
    public class PerfilQueryResult
    {
        public IEnumerable<Appliaction.Domain.Entities.Perfil> ListPerfil { get;  }

        public PerfilQueryResult(IEnumerable<Appliaction.Domain.Entities.Perfil> perfil)
        {
            ListPerfil = perfil;
        }
    }
}
