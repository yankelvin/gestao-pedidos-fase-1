using Domain.Models.Promocoes;
using Domain.Ports.Driven.Promocoes;
using Domain.Ports.Driving.Promocoes;

namespace Domain.UseCases.Promocoes
{
    public class AtualizarItemPromocao : IAtualizarItemPromocao
    {
        private readonly IItemPromocaoPersistencePort _itemPromocaoPersistencePort;

        public AtualizarItemPromocao(IItemPromocaoPersistencePort itemPromocaoPersistencePort)
        {
            _itemPromocaoPersistencePort = itemPromocaoPersistencePort;
        }

        public async Task Executar(ItemPromocao itemPromocao)
        {
            await _itemPromocaoPersistencePort.Atualizar(itemPromocao);
        }
    }
}
