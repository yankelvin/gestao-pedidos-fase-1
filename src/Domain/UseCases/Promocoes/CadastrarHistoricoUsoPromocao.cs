using Domain.Models.Promocoes;
using Domain.Ports.Driven.Promocoes;
using Domain.Ports.Driving.Promocoes;

namespace Domain.UseCases.Promocoes
{
    public class CadastrarHistoricoUsoPromocao : ICadastrarHistoricoUsoPromocao
    {
        private readonly IHistoricoUsoPromocaoPersistencePort _historicoUsoPromocaoPersistencePort;

        public CadastrarHistoricoUsoPromocao(IHistoricoUsoPromocaoPersistencePort promocaoPersistencePort)
        {
            _historicoUsoPromocaoPersistencePort = promocaoPersistencePort;
        }

        public async Task Executar(HistoricoUsoPromocao historico)
        {
            await _historicoUsoPromocaoPersistencePort.InserirUsoPromocao(historico);
        }
    }
}
