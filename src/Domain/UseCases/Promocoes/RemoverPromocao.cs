using Domain.Ports.Driven.Promocoes;
using Domain.Ports.Driving.Promocoes;

namespace Domain.UseCases.Promocoes
{
    public class RemoverPromocao : IRemoverPromocao
    {
        private readonly IPromocaoPersistencePort _promocaoPersistencePort;

        public RemoverPromocao(IPromocaoPersistencePort promocaoPersistencePort)
        {
            _promocaoPersistencePort = promocaoPersistencePort;
        }

        public async Task Executar(int promocaoId)
        {
            await _promocaoPersistencePort.Remover(promocaoId);
        }
    }
}
