
using System;

namespace Application.Appliaction.Domain.Entities
{
    public class ProjetoHoras : Entity
    {
        public Guid ColaboradorId { get; set; }
        public Guid ProjetoId { get; set; }
        public DateTime MesDia { get; set; }
        public decimal Horas { get; set; }

        public Colaborador Colaborador { get; set; }
        public Projeto Projeto { get; set; }
    }
}
