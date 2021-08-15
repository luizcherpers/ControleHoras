using Application.Appliaction.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Queries.Perfil
{
    public class PerfilQueryHandler : IRequestHandler<PerfilQueryRequest, PerfilQueryResult>
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilQueryHandler(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public async Task<PerfilQueryResult> Handle(PerfilQueryRequest request, CancellationToken cancellationToken)
        {
            var perfil = await _perfilRepository.GetPerfis();
            return new PerfilQueryResult(perfil);
        }
    }
}