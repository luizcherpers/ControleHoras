using Application.Appliaction.Domain.Interfaces.Queries;
using System.ComponentModel.DataAnnotations;

namespace Application.Application.Core.Queries.Colaboradores
{
    public class AutenticacaoRequest : IQuery<AutenticacaoResult>
    {
        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "The {0} field is in invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, ErrorMessage = "The field must be between {2} and {1} characters")]
        public string Senha { get; set; }
    }
}
