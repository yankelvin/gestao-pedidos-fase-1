using Domain.Models.Produtos;
using Domain.Ports.Driven.Produtos;
using Domain.Ports.Driving.Produtos;

namespace Domain.UseCases.Produtos
{
    public class ObterProduto : IObterProduto
    {
        private readonly IProdutoPersistencePort _produtoPersistencePort;

        public ObterProduto(IProdutoPersistencePort produtoPersistencePort)
        {
            _produtoPersistencePort = produtoPersistencePort;
        }

        public Task<IEnumerable<Produto>> Executar()
        {
            return _produtoPersistencePort.Obter();
        }

        public Task<Produto?> Executar(int produtoId)
        {
            return _produtoPersistencePort.Obter(produtoId);
        }

        public Task<IEnumerable<Produto>> ExecutarPorCategoria(int categoriaId)
        {
            return _produtoPersistencePort.ObterPorCategoria(categoriaId);
        }
    }
}
