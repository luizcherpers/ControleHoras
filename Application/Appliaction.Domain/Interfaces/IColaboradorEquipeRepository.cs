using Application.Appliaction.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Appliaction.Domain.Interfaces
{
    public interface IColaboradorEquipeRepository
    {
        Task<ColaboradorEquipe> GteByIdColaboradorEquipe(Guid colaboradorId, Guid EquipeId);
        Task<int> Create(ColaboradorEquipe colaboradorEquipe);
        Task<int> Update(ColaboradorEquipe colaboradorEquipe);
    }
}
