
using Application.Appliaction.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Queries.Equipes
{
    public class EquipeHandler : IRequestHandler<EquipeRequest, EquipeResult>
    {
        private readonly IEquipeRepository _equipeRepository;

        public EquipeHandler(IEquipeRepository equipeRepository)
        {
            _equipeRepository = equipeRepository;
        }

        public async Task<EquipeResult> Handle(EquipeRequest request, CancellationToken cancellationToken)
        {
            var result = await _equipeRepository.GetByAll();

            return new EquipeResult();
        }
    }
}
