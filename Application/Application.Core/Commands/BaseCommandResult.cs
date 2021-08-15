using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Application.Core.Commands
{
    public abstract class BaseCommandResult
    {
        public string Message { get; protected set; }
    }
}
