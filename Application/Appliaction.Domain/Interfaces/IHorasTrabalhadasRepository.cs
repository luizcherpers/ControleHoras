using Application.Appliaction.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Appliaction.Domain.Interfaces
{
    public interface IHorasTrabalhadasRepository
    {
        Task<ProjetoHoras> GetById(Guid id);
        Task<int> Create(ProjetoHoras horas);
        Task<int> Update(ProjetoHoras horas);
        Task<int> Delete(ProjetoHoras horas);
    }
}
