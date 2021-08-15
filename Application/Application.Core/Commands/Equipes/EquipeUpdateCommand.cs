using Application.Appliaction.Domain.Interfaces.Commands;
using System;

namespace Application.Application.Core.Commands.Equipes
{
    public class EquipeUpdateCommand : ICommand<EquipeUpdateResult>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
