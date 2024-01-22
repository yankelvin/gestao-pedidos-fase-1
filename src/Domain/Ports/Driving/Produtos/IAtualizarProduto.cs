using Domain.Models.Produtos;

namespace Domain.Ports.Driving.Produtos
{
    public interface IAtualizarProduto
    {
        Task Executar(Produto produto);
    }
}
