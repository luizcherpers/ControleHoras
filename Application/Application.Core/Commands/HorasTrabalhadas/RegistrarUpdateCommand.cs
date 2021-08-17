using Application.Appliaction.Domain.Interfaces.Commands;
using System;
using System.Text.Json.Serialization;

namespace Application.Application.Core.Commands.HorasTrabalhadas
{
    public class RegistrarUpdateCommand : ICommand<RegistrarUpdateResult>
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid ColaboradorId { get; set; }
        public Guid ProjetoId { get; set; }
        public DateTime MesDia { get; set; }
        public decimal Horas { get; set; }
    }
}
