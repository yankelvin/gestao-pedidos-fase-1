using Domain.Models.Promocoes;
using Domain.Ports.Driven.Promocoes;
using Domain.Ports.Driving.Promocoes;

namespace Domain.UseCases.Promocoes
{
    public class ObterPromocao : IObterPromocao
    {
        private readonly IPromocaoPersistencePort _promocaoPersistencePort;

        public ObterPromocao(IPromocaoPersistencePort promocaoPersistencePort)
        {
            _promocaoPersistencePort = promocaoPersistencePort;
        }

        public Task<IEnumerable<Promocao>> Executar()
        {
            return _promocaoPersistencePort.Obter();
        }

        public Task<Promocao?> Executar(int promocaoId)
        {
            return _promocaoPersistencePort.Obter(promocaoId);
        }
    }
}
