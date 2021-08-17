using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Interfaces;
using Application.Appliaction.Domain.Interfaces.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Core.Commands.HorasTrabalhadas
{
    public class RegistrarCreateHandler : 
        ICommandHandler<RegistrarCreateCommand, RegistrarCreateResult>,
        ICommandHandler<RegistrarUpdateCommand, RegistrarUpdateResult>
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IHorasTrabalhadasRepository _horasTrabalhadasRepository;

        public RegistrarCreateHandler(
            IProjetoRepository projetoRepository,
            IHorasTrabalhadasRepository horasTrabalhadasRepository
            )
        {
            _projetoRepository = projetoRepository;
            _horasTrabalhadasRepository = horasTrabalhadasRepository;
        }

        public async Task<RegistrarCreateResult> Handle(RegistrarCreateCommand request, CancellationToken cancellationToken)
        {
            if (request.Horas <= 0)
                return new RegistrarCreateResult("Quantidade deve horas de ser informado!");

            var projeto = await _projetoRepository.GetById(request.ProjetoId);
            if (projeto == null)
                return new RegistrarCreateResult(" Projeto deve ser informado!");


            var projetoHoras = new ProjetoHoras()
            {
                ColaboradorId = request.ColaboradorId,
                ProjetoId = request.ProjetoId,
                Horas = request.Horas,
                MesDia = request.MesDia
            };

            var response = await _horasTrabalhadasRepository.Create(projetoHoras);
            if (response > 0)
            {
                return new RegistrarCreateResult("Lançamento inserido com sucesso!");
            }
            else
            {
                return new RegistrarCreateResult("Erro ao lançar horas!");
            }
        }

        public async Task<RegistrarUpdateResult> Handle(RegistrarUpdateCommand request, CancellationToken cancellationToken)
        {
            var lancamento = await _horasTrabalhadasRepository.GetById(request.Id);
            if (lancamento == null)
                return new RegistrarUpdateResult(" Lançamento não encontrado!");

            if (request.Horas <= 0)
                return new RegistrarUpdateResult("Quantidade deve horas de ser informado!");

            var projeto = await _projetoRepository.GetById(request.ProjetoId);
            if (projeto == null)
                return new RegistrarUpdateResult(" Projeto deve ser informado!");

            lancamento.Horas = request.Horas;
            lancamento.MesDia = request.MesDia;

            var response = await _horasTrabalhadasRepository.Update(lancamento);
            if (response > 0)
            {
                return new RegistrarUpdateResult("Lançamento atualizado com sucesso!");
            }
            else
            {
                return new RegistrarUpdateResult("Erro ao autlizar lançamento!");
            }
        }
    }
}
