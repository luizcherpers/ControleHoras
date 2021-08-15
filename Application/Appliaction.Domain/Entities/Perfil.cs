using Application.Appliaction.Domain.Enumerados;
using System.Collections.Generic;

namespace Application.Appliaction.Domain.Entities
{
    public class Perfil : Entity
    {
        public Perfil()
        {
            Colaborador = new HashSet<Colaborador>();
        }

        public string Descricao { get; set; }
        public PerfilEnum PerfilEnum { get; set; }

        public virtual ICollection<Colaborador> Colaborador { get; set; }
    }
}
