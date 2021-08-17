using Application.Appliaction.Domain.Interfaces.Commands;
using System;

namespace Application.Application.Core.Commands.Colaboradores
{
    public class ColaboradorUpdateCommand : ICommand<ColaboradorUpdateResultCommand>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Guid EquipeId { get; set; }
    }
}
