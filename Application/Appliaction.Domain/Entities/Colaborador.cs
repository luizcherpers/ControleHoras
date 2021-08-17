using System;
using System.Collections.Generic;

namespace Application.Appliaction.Domain.Entities
{
    public class Colaborador : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Guid PerfilId { get; set; }

        public Perfil Perfil { get; private set; }
        public ICollection<ColaboradorEquipe> ColaboradorEquipes { get; set; }
        public ICollection<ProjetoHoras> ProjetoHoras { get; set; }
    }
}
