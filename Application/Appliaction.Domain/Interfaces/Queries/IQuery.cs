using MediatR;

namespace Application.Appliaction.Domain.Interfaces.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
