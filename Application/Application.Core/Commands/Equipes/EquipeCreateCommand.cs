using Application.Appliaction.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Application.Core.Commands.Equipes
{
    public class EquipeCreateCommand : ICommand<EquipeCreateResult>
    {
        public string Descricao { get; set; }
    }
}
