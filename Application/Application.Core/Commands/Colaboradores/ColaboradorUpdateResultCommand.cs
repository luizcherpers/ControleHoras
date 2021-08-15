using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Application.Core.Commands.Colaboradores
{
    public class ColaboradorUpdateResultCommand : BaseCommandResult
    {
        public ColaboradorUpdateResultCommand(string message)
        {
            Message = message;
        }
    }
}
