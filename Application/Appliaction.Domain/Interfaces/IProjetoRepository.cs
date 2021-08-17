using Application.Appliaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Appliaction.Domain.Interfaces
{
    public interface IProjetoRepository
    {
        Task<Projeto> GetById(Guid id);
        Task<List<Projeto>> GetAll();
        Task<int> Create(Projeto projeto);
        Task<int> Update(Projeto projeto);
        Task<int> Delete(Projeto projeto);
    }
}
