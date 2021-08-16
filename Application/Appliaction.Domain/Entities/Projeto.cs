
using System.Collections.Generic;

namespace Application.Appliaction.Domain.Entities
{
    public class Projeto : Entity
    {
        public string Descricao { get; set; }
        public ICollection<ProjetoHoras> ProjetoHoras { get; set; }
    }
}