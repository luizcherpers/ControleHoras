using Application.Appliaction.Domain.Interfaces;
using Application.Appliaction.Domain.Interfaces.Commands;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Commands.Colaboradores
{
    public class ColaboradorUpdateCommandHandler : ICommandHandler<ColaboradorUpdateCommand, ColaboradorUpdateResultCommand>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorUpdateCommandHandler(
            IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
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

            
            colaborador.Nome = request.Nome;
            colaborador.Email = request.Email;
            colaborador.Senha = request.Senha;
            
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
}
