using Domain.Models.Produtos;

namespace Domain.Ports.Driving.Produtos
{
    public interface IAtualizarCategoriaProduto
    {
        Task Executar(CategoriaProduto categoriaProduto);
    }
}
