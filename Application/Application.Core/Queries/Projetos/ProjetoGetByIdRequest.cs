using Application.Appliaction.Domain.Interfaces.Queries;
using System;

namespace Application.Application.Core.Queries.Projetos
{
    public class ProjetoGetByIdRequest : IQuery<ProjetoGetByIdResult>
    {
        public Guid Id { get; }

        public ProjetoGetByIdRequest( Guid id)
        {
            Id = id;
        }
    }
}
