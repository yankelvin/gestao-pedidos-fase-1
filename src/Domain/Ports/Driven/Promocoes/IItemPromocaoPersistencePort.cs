using Domain.Models.Promocoes;

namespace Domain.Ports.Driven.Promocoes
{
    public interface IItemPromocaoPersistencePort
    {
        Task<IEnumerable<ItemPromocao>> ObterPorPromocao(int promocaoId);
        Task<IEnumerable<ItemPromocao>> ObterPorProduto(int produtoId);
        Task Cadastrar(ItemPromocao promocao);
        Task Atualizar(ItemPromocao promocao);
        Task Remover(int promocaoId);
    }
}
