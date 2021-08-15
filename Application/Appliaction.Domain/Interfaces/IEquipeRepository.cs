using Application.Appliaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Appliaction.Domain.Interfaces
{
    public interface IEquipeRepository
    {
        Task<int> Create(Equipe equipe);
        Task<int> Update(Equipe equipe);
        Task<int> Delete(Equipe equipe);
        Task<Equipe> GetById(Guid id);
        Task<List<Equipe>> GetByAll();
    }
}
