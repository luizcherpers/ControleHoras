using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Interfaces;
using Application.Appliaction.Domain.Interfaces.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Commands.Equipes
{
    public class EquipeUpdateCommandHandler : ICommandHandler<EquipeUpdateCommand, EquipeUpdateResult>
    {
        private readonly IEquipeRepository _equipeRepository;

        public EquipeUpdateCommandHandler(IEquipeRepository equipeRepository)
        {
            _equipeRepository = equipeRepository;
        }

        public async Task<EquipeUpdateResult> Handle(EquipeUpdateCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Descricao))
                return new EquipeUpdateResult("Todos os campos devem ser informados!");

            var equipe = await _equipeRepository.GetById(request.Id);
            if (equipe == null)
                return new EquipeUpdateResult("Todos os campos devem ser informados!");

            equipe.Descricao = request.Descricao;
            var response = await _equipeRepository.Update(equipe);
            if (response > 0)
            {
                return new EquipeUpdateResult("Equipe atualizada com sucesso!");
            }
            else
            {
                return new EquipeUpdateResult("Erro na ediçao da equipe!");
            }
        }
    }
}
