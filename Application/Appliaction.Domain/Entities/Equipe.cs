using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Appliaction.Domain.Entities
{
    public class Equipe :  Entity
    {
        public string Descricao { get; set; }
        public ICollection<ColaboradorEquipe> ColaboradorEquipes { get; set; }
    }
}
