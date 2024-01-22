using Domain.Models.Promocoes;
using Domain.Ports.Driven.Promocoes;
using Domain.Ports.Driving.Promocoes;

namespace Domain.UseCases.Promocoes
{
    public class ObterHistoricoUsoPromocao : IObterHistoricoUsoPromocao
    {
        private readonly IHistoricoUsoPromocaoPersistencePort _historicoUsoPromocaoPersistencePort;

        public ObterHistoricoUsoPromocao(IHistoricoUsoPromocaoPersistencePort historicoUsoPromocaoPersistencePort)
        {
            _historicoUsoPromocaoPersistencePort = historicoUsoPromocaoPersistencePort;
        }

        public Task<IEnumerable<HistoricoUsoPromocao>> Executar(int clienteId)
        {
            return _historicoUsoPromocaoPersistencePort.ObterPorCliente(clienteId);
        }
    }
}
