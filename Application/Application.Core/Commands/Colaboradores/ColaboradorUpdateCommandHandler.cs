using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Interfaces;
using Application.Appliaction.Domain.Interfaces.Commands;
using FluentValidation;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Commands.Colaboradores
{
    public class ColaboradorUpdateCommandHandler : ICommandHandler<ColaboradorUpdateCommand, ColaboradorUpdateResultCommand>
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IColaboradorEquipeRepository _colaboradorEquipeRepository;
        private readonly IEquipeRepository _equipeRepository;

        public ColaboradorUpdateCommandHandler(
            IColaboradorRepository colaboradorRepository,
            IColaboradorEquipeRepository colaboradorEquipeRepository,
            IEquipeRepository equipeRepository)
        {
            _colaboradorRepository = colaboradorRepository;
            _colaboradorEquipeRepository = colaboradorEquipeRepository;
            _equipeRepository = equipeRepository;
        }

        public async Task<ColaboradorUpdateResultCommand> Handle(ColaboradorUpdateCommand request, CancellationToken cancellationToken)
        {
            var colaboradorCreateValidation = new ColaboradorUpdateCreateValidation();
            var validationResult = colaboradorCreateValidation.Validate(request);

            if (!validationResult.IsValid)
                return new ColaboradorUpdateResultCommand("Todos os campos devem ser informados!");

            var colaborador = await _colaboradorRepository.GetById(request.Id);

            if (colaborador == null)
                return new ColaboradorUpdateResultCommand("Colaborador não encontrado!");

            var equipe = await _equipeRepository.GetById(request.EquipeId);
            if (equipe == null)
                return new ColaboradorUpdateResultCommand("Equipe não encontrada!");

            var colaboradorEquipe = _colaboradorEquipeRepository.GteByIdColaboradorEquipe(request.Id, request.EquipeId);
            if(colaboradorEquipe == null)
                return new ColaboradorUpdateResultCommand("Relação colaborador/equipe não encontrada!");

            var senhaProtegida = System.Convert.ToBase64String(Encoding.ASCII.GetBytes(request.Senha));
            var senhaUpdate = colaborador.Senha.Equals(senhaProtegida) ? colaborador.Senha : senhaProtegida;
            colaborador.Nome = request.Nome;
            colaborador.Email = request.Email;
            colaborador.Senha = senhaUpdate;

            var response = await _colaboradorRepository.Update(colaborador);
            if (response > 0)
            {
                return new ColaboradorUpdateResultCommand("Colaborador atualizado com sucesso!");
            }
            else
            {
                return new ColaboradorUpdateResultCommand("Erro ao editar colaborador!");
            }
        }

        private async Task<bool> AtualizaColaboradorEquipe(Guid colaboradorId, Guid equipeId)
        {
            var colaboradorEquipe = new ColaboradorEquipe();
            colaboradorEquipe.ColaboradorId = colaboradorId;
            colaboradorEquipe.EquipeId = equipeId;
            var result = await _colaboradorEquipeRepository.Update(colaboradorEquipe);
            return result > 0;
        }

    }

    public class ColaboradorUpdateCreateValidation : AbstractValidator<ColaboradorUpdateCommand>
    {

        public ColaboradorUpdateCreateValidation()
        {
            RuleFor(r => r.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(r => r.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("E-mail é obrigatório");

            RuleFor(r => r.Senha)
                .NotNull()
                .NotEmpty()
                .WithMessage("Senha é obrigatório");
        }
    }
}

