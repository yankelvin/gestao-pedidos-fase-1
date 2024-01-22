using Domain.Models.Produtos;

namespace Domain.Ports.Driving.Produtos
{
    public interface IObterProduto
    {
        Task<IEnumerable<Produto>> Executar();
        Task<Produto?> Executar(int produtoId);
        Task<IEnumerable<Produto>> ExecutarPorCategoria(int categoriaId);

    }
}
