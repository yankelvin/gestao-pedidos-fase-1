using Domain.Models.Promocoes;
using Domain.Ports.Driven.Promocoes;
using Domain.Ports.Driving.Promocoes;

namespace Domain.UseCases.Promocoes
{
    public class ObterItemPromocao : IObterItemPromocao
    {
        private readonly IItemPromocaoPersistencePort _itemPromocaoPersistencePort;

        public ObterItemPromocao(IItemPromocaoPersistencePort itemPromocaoPersistencePort)
        {
            _itemPromocaoPersistencePort = itemPromocaoPersistencePort;
        }

        public Task<IEnumerable<ItemPromocao>> ExecutarPorPromocao(int promocaoId)
        {
            return _itemPromocaoPersistencePort.ObterPorPromocao(promocaoId);
        }

        public Task<IEnumerable<ItemPromocao>> ExecutarPorProduto(int produtoId)
        {
            return _itemPromocaoPersistencePort.ObterPorProduto(produtoId);
        }
    }
}
