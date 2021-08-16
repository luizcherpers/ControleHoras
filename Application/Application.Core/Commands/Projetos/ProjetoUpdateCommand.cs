using Application.Appliaction.Domain.Interfaces.Commands;
using System;

namespace Application.Application.Core.Commands.Projetos
{
    public class ProjetoUpdateCommand : ICommand<ProjetoUpdateResult>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
