namespace Domain.Ports.Driving.Promocoes
{
    public interface IRemoverPromocao
    {
        Task Executar(int promocaoId);
    }
}
