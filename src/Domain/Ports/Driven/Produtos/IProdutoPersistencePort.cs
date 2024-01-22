using Domain.Models.Produtos;

namespace Domain.Ports.Driven.Produtos
{
    public interface IProdutoPersistencePort
    {
        Task<IEnumerable<Produto>> ObterPorCategoria(int categoriaId);
        Task<IEnumerable<Produto>> Obter();
        Task<Produto?> Obter(int produtoId);
        Task Cadastrar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(int produtoId);
    }
}
