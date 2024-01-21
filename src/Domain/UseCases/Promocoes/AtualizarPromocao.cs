using Domain.Models.Promocoes;
using Domain.Ports.Driven.Promocoes;
using Domain.Ports.Driving.Promocoes;

namespace Domain.UseCases.Promocoes
{
    public class AtualizarPromocao : IAtualizarPromocao
    {
        private readonly IPromocaoPersistencePort _promocaoPersistencePort;

        public AtualizarPromocao(IPromocaoPersistencePort promocaoPersistencePort)
        {
            _promocaoPersistencePort = promocaoPersistencePort;
        }

        public async Task Executar(Promocao promocao)
        {
            await _promocaoPersistencePort.Atualizar(promocao);
        }
    }
}
