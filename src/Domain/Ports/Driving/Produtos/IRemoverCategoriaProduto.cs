namespace Domain.Ports.Driving.Produtos
{
    public interface IRemoverCategoriaProduto
    {
        Task Executar(int categoriaId);
    }
}
