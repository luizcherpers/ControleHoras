using Application.Appliaction.Domain.Interfaces.Commands;

namespace Application.Application.Core.Commands.Projetos
{
    public class ProjetoCreateCommand : ICommand<ProjetoCreateResult>
    {
        public string Descricao { get; set; }
    }
}
