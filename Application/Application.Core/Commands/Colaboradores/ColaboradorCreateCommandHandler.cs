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
    public class ColaboradorCreateCommandHandler : ICommandHandler<ColaboradorCreateCommand, ColaboradorCreateResultCommand>
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IColaboradorEquipeRepository _colaboradorEquipeRepository;
        private readonly IEquipeRepository _equipeRepository;

        public ColaboradorCreateCommandHandler(
            IColaboradorRepository colaboradorRepository,
            IPerfilRepository perfilRepository,
            IColaboradorEquipeRepository colaboradorEquipeRepository,
            IEquipeRepository equipeRepository)
        {
            _colaboradorRepository = colaboradorRepository;
            _perfilRepository = perfilRepository;
            _colaboradorEquipeRepository = colaboradorEquipeRepository;
            _equipeRepository = equipeRepository;
        }

        public async Task<ColaboradorCreateResultCommand> Handle(ColaboradorCreateCommand request, CancellationToken cancellationToken)
        {
            var colaboradorCreateValidation = new ColaboradorCreateValidation();
            var validationResult = colaboradorCreateValidation.Validate(request);

            if (!validationResult.IsValid)
                return new ColaboradorCreateResultCommand("Todos os campos devem ser informados!");

            var perfil = await _perfilRepository.GetByEnum(request.PerfilEnum);

            if (perfil == null)
                return new ColaboradorCreateResultCommand("Perfil não encontrado!");

            var equipe = await _equipeRepository.GetById(request.EquipeId);
            if (equipe == null)
                return new ColaboradorCreateResultCommand("Equipe não encontrada!");

            var senhaProtegida = System.Convert.ToBase64String(Encoding.ASCII.GetBytes(request.Senha));

            var colaborador = new Colaborador();
            colaborador.Nome = request.Nome;
            colaborador.Email = request.Email;
            colaborador.Senha = senhaProtegida;
            colaborador.PerfilId = perfil.Id;
            var response = await _colaboradorRepository.Create(colaborador);
            if (response > 0)
            {
                await GravarColaboradorEquipe(colaborador.Id, request.EquipeId);
                return new ColaboradorCreateResultCommand("Colaborador inserido com sucesso!");
            }
            else
            {
                return new ColaboradorCreateResultCommand("Erro ao inserir colaborador!");
            }
        }

        private async Task<bool> GravarColaboradorEquipe(Guid colaboradorId, Guid equipeId)
        {
            var colaboradorEquipe = new ColaboradorEquipe();
            colaboradorEquipe.ColaboradorId = colaboradorId;
            colaboradorEquipe.EquipeId = equipeId;
            var result = await _colaboradorEquipeRepository.Create(colaboradorEquipe);
            return result > 0;
        }
    }

    public class ColaboradorCreateValidation : AbstractValidator<ColaboradorCreateCommand>
    {

        public ColaboradorCreateValidation()
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

            RuleFor(r => r.PerfilEnum)
                .NotNull()
                .WithMessage("Perfil é obrigatório");
        }
    }
}
