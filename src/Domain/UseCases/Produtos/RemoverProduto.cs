using Domain.Ports.Driven.Produtos;
using Domain.Ports.Driving.Produtos;

namespace Domain.UseCases.Produtos
{
    public class RemoverProduto : IRemoverProduto
    {
        private readonly IProdutoPersistencePort _produtoPersistencePort;

        public RemoverProduto(IProdutoPersistencePort produtoPersistencePort)
        {
            _produtoPersistencePort = produtoPersistencePort;
        }

        public async Task Executar(int produtoId)
        {
            await _produtoPersistencePort.Remover(produtoId);
        }
    }
}
