using Domain.Models.Produtos;

namespace Domain.Ports.Driving.Produtos
{
    public interface ICadastrarProduto
    {
        Task Executar(Produto produto);
    }
}
