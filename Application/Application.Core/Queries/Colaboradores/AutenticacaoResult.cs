
namespace Application.Application.Core.Queries.Colaboradores
{
    public class AutenticacaoResult
    {
        public string Message { get; }
        public string Token { get; }

        public AutenticacaoResult(string token, string message = null)
        {
            Token = token;
            Message = message;
        }
    }
}
