using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Interfaces;
using Application.Appliaction.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Commands.Equipes
{
    public class EquipeCreateCommandHandler : ICommandHandler<EquipeCreateCommand, EquipeCreateResult>
    {
        private readonly IEquipeRepository _equipeRepository;

        public EquipeCreateCommandHandler(IEquipeRepository equipeRepository)
        {
            _equipeRepository = equipeRepository;
        }

        public async Task<EquipeCreateResult> Handle(EquipeCreateCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Descricao))
                return new EquipeCreateResult("Todos os campos devem ser informados!");

            var equipe = new Equipe();
            equipe.Descricao = request.Descricao;
            var response = await _equipeRepository.Create(equipe);
            if (response > 0)
            {
                return new EquipeCreateResult("Equipe inserida com sucesso!");
            }
            else
            {
                return new EquipeCreateResult("Erro ao inserir equipe!");
            }
        }
    }
}
