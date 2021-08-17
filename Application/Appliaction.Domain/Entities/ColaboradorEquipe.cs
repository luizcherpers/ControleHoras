using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Appliaction.Domain.Entities
{
    public class ColaboradorEquipe : Entity
    {
        public Guid ColaboradorId { get; set; }
        public Guid EquipeId { get; set; }

        public Colaborador Colaborador { get; set; }
        public Equipe Equipe { get; set; }

    }
}
