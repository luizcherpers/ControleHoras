using Application.Appliaction.Domain.Entities;
using System.Collections.Generic;

namespace Application.Application.Core.Queries.Colaboradores
{
    public class ColaboradorAllResult
    {
        public IEnumerable<Colaborador> ListColaborador { get; }

        public ColaboradorAllResult(IEnumerable<Colaborador> listColaborador)
        {
            ListColaborador = listColaborador;
        }
    }
}
