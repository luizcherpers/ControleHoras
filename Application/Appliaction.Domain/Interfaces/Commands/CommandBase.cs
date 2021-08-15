using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appliaction.Domain.Interfaces.Commands
{
    public class CommandBase : ICommand
    {

    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
    }
}