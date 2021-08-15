using Application.Appliaction.Domain.Enumerados;
using Application.Appliaction.Domain.Interfaces.Commands;

namespace Application.Application.Core.Commands.Colaboradores
{
    public class ColaboradorCreateCommand : ICommand<ColaboradorCreateResultCommand>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public PerfilEnum PerfilEnum { get; set; }
    }
}
