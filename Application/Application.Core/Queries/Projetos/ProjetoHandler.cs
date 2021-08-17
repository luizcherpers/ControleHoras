using Application.Appliaction.Domain.Interfaces;
using Application.Appliaction.Domain.Interfaces.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Queries.Projetos
{
    public class ProjetoHandler : 
        IQueryHandler<ProjetoGetAllRequest, ProjetoGetAllResult>,
        IQueryHandler<ProjetoGetByIdRequest, ProjetoGetByIdResult>
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoHandler(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }
        public async Task<ProjetoGetAllResult> Handle(ProjetoGetAllRequest request, CancellationToken cancellationToken)
        {
            var projetos = await _projetoRepository.GetAll();

            return new ProjetoGetAllResult(projetos);
        }

        public async Task<ProjetoGetByIdResult> Handle(ProjetoGetByIdRequest request, CancellationToken cancellationToken)
        {
            var projeto = await _projetoRepository.GetById(request.Id);

            return new ProjetoGetByIdResult(projeto);
        }
    }
}
