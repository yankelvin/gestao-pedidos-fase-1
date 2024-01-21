namespace Domain.Ports.Driving.Promocoes
{
    public interface IRemoverItemPromocao
    {
        Task Executar(int promocaoId);
    }
}
