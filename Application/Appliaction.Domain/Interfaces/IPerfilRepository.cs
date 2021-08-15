using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Appliaction.Domain.Interfaces
{
    public interface IPerfilRepository
    {

        Task<IEnumerable<Perfil>> GetPerfis();
        Task<Perfil> GetByEnum(PerfilEnum perfilEnum);
    }
}
