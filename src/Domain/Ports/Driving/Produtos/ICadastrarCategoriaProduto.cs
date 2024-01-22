using Domain.Models.Produtos;

namespace Domain.Ports.Driving.Produtos
{
    public interface ICadastrarCategoriaProduto
    {
        Task Executar(CategoriaProduto categoriaProduto);
    }
}
