using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Interfaces;
using Application.Appliaction.Domain.Interfaces.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Commands.Projetos
{
    public class ProjetoHandler : 
        ICommandHandler<ProjetoCreateCommand, ProjetoCreateResult>,
        ICommandHandler<ProjetoUpdateCommand, ProjetoUpdateResult>
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoHandler(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<ProjetoCreateResult> Handle(ProjetoCreateCommand request, CancellationToken cancellationToken)
        {
            var projeto = new Projeto();
            projeto.Descricao = request.Descricao;

            var result = await _projetoRepository.Create(projeto);
            if (result > 0)
            {
                return new ProjetoCreateResult("Projeto inserido com sucesso!");
            }
            else
            {
                return new ProjetoCreateResult("Erro ao adicionar projeto!");
            }
        }

        public async Task<ProjetoUpdateResult> Handle(ProjetoUpdateCommand request, CancellationToken cancellationToken)
        {
            var projeto = await _projetoRepository.GetById(request.Id);
            if(projeto == null)
            return new ProjetoUpdateResult("Projeto não encontrado!");

            projeto.Descricao = request.Descricao;

            var result = await _projetoRepository.Update(projeto);
            if (result > 0)
            {
                return new ProjetoUpdateResult("Projeto atualizado com sucesso!");
            }
            else
            {
                return new ProjetoUpdateResult("Erro ao atualizazr projeto!");
            }

        }
    }
}
