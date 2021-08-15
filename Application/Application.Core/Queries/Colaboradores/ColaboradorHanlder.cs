using Application.Appliaction.Domain.Interfaces;
using Application.Appliaction.Domain.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Queries.Colaboradores
{
    public class ColaboradorHanlder : IQueryHandler<ColaboradorAllRequest, ColaboradorAllResult>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorHanlder(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<ColaboradorAllResult> Handle(ColaboradorAllRequest request, CancellationToken cancellationToken)
        {
            var colaboradores = await _colaboradorRepository.GetAll();

            return new ColaboradorAllResult(colaboradores);
        }
    }
}
