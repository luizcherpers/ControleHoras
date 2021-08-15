
using Application.Appliaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Appliaction.Domain.Interfaces
{
    public interface IColaboradorRepository
    {
        Task<Colaborador> GetById(Guid id);
        Task<int> Create(Colaborador colaborador);
        Task<int> Update(Colaborador colaborador);
        Task<int> Delete(Colaborador colaborador);
        Task<IEnumerable<Colaborador>> GetAll();
    }
}
