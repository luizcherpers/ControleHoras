using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Interfaces;
using Application.Appliaction.Domain.Interfaces.Commands;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Commands.Colaboradores
{
    public class ColaboradorCreateCommandHandler : ICommandHandler<ColaboradorCreateCommand, ColaboradorCreateResultCommand>
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IPerfilRepository _perfilRepository;

        public ColaboradorCreateCommandHandler(
            IColaboradorRepository colaboradorRepository,
            IPerfilRepository perfilRepository)
        {
            _colaboradorRepository = colaboradorRepository;
            _perfilRepository = perfilRepository;
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

            var colaborador = new Colaborador();
            colaborador.Nome = request.Nome;
            colaborador.Email = request.Email;
            colaborador.Senha = request.Senha;
            colaborador.PerfilId = perfil.Id;
            var response = await _colaboradorRepository.Create(colaborador);
            if (response > 0)
            {
                return new ColaboradorCreateResultCommand("Colaborador inserido com sucesso!");
            }
            else
            {
                return new ColaboradorCreateResultCommand("Erro ao inserir colaborador!");
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
}
