using Application.Appliaction.Domain.Entities;

namespace Application.Application.Core.Queries.Projetos
{
    public class ProjetoGetByIdResult
    {
        public Projeto Projeto { get; }

        public ProjetoGetByIdResult(Projeto projeto)
        {
            Projeto = projeto;
        }
    }
}
