using MediatR;

namespace Application.Appliaction.Domain.Interfaces.Commands
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}