using Domain.Models.Promocoes;

namespace Domain.Ports.Driving.Promocoes
{
    public interface IObterItemPromocao
    {
        Task<IEnumerable<ItemPromocao>> ExecutarPorPromocao(int promocaoId);
        Task<IEnumerable<ItemPromocao>> ExecutarPorProduto(int produtoId);
    }
}
