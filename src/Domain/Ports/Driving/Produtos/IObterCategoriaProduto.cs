using Domain.Models.Produtos;

namespace Domain.Ports.Driving.Produtos
{
    public interface IObterCategoriaProduto
    {
        Task<IEnumerable<CategoriaProduto>> Executar();
        Task<CategoriaProduto?> Executar(int categoriaId);
    }
}
