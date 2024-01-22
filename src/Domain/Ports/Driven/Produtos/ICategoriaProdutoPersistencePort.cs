using Domain.Models.Produtos;

namespace Domain.Ports.Driven.Produtos
{
    public interface ICategoriaProdutoPersistencePort
    {
        Task<IEnumerable<CategoriaProduto>> Obter();
        Task<CategoriaProduto?> Obter(int categoriaId);
        Task Cadastrar(CategoriaProduto categoria);
        Task Atualizar(CategoriaProduto categoria);
        Task Remover(int categoriaId);
    }
}
