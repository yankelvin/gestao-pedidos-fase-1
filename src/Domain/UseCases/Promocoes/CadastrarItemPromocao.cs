using Domain.Models.Promocoes;
using Domain.Ports.Driven.Promocoes;
using Domain.Ports.Driving.Promocoes;

namespace Domain.UseCases.Promocoes
{
    public class CadastrarItemPromocao : ICadastrarItemPromocao
    {
        private readonly IItemPromocaoPersistencePort _itemPromocaoPersistencePort;

        public CadastrarItemPromocao(IItemPromocaoPersistencePort promocaoPersistencePort)
        {
            _itemPromocaoPersistencePort = promocaoPersistencePort;
        }

        public async Task Executar(ItemPromocao itemPromocao)
        {
            await _itemPromocaoPersistencePort.Cadastrar(itemPromocao);
        }
    }
}
