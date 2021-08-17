using Application.Appliaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Application.Core.Queries.Projetos
{
    public class ProjetoGetAllResult
    {
        public List<Projeto> ListProjeto { get; }

        public ProjetoGetAllResult(List<Projeto> projetos)
        {
            ListProjeto = projetos;
        }
    }
}
