namespace Domain.Ports.Driving.Usuarios
{
    public interface IRemoverUsuario
    {
        Task Executar(int usuarioId);
    }
}
