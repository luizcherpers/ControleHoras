using System.Threading.Tasks;

namespace Application.Appliaction.Domain.Interfaces
{
    public interface IVerificarPerfilGestor
    {
        IVerificarPerfilGestor SetToken(string token);
        bool TemPerfilGestor();
    }
}
