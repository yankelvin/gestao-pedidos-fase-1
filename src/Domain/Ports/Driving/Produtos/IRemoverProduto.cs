namespace Domain.Ports.Driving.Produtos
{
    public interface IRemoverProduto
    {
        Task Executar(int produtoId);
    }
}
