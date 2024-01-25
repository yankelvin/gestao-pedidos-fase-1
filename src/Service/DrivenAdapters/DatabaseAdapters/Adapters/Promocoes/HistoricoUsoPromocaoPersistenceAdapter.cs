using AutoMapper;
using Domain.Models.Promocoes;
using Domain.Ports.Driven.Promocoes;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes;

namespace Service.DrivenAdapters.DatabaseAdapters.Adapters.Promocoes
{
    public class HistoricoUsoPromocaoPersistenceAdapter : IHistoricoUsoPromocaoPersistencePort
    {
        private readonly IMapper _mapper;
        private readonly PromocaoContext _promocaoContext;

        public HistoricoUsoPromocaoPersistenceAdapter(IMapper mapper, PromocaoContext promocaoContext)
        {
            _mapper = mapper;
            _promocaoContext = promocaoContext;
        }

        public async Task InserirUsoPromocao(HistoricoUsoPromocao historicoUsoPromocao)
        {
            var entity = _mapper.Map<HistoricoUsoPromocaoEntity>(historicoUsoPromocao);
            await _promocaoContext.HistoricosUsoPromocoes.AddAsync(entity);
            await _promocaoContext.SaveChangesAsync();
        }

        public Task<IEnumerable<HistoricoUsoPromocao>> ObterPorCliente(int clienteId)
        {
            var entities = _promocaoContext.HistoricosUsoPromocoes.Where(i => i.idCliente.Equals(clienteId));
            var historico = _mapper.Map<IEnumerable<HistoricoUsoPromocao>>(entities);
            return Task.FromResult(historico);
        }
    }
}
