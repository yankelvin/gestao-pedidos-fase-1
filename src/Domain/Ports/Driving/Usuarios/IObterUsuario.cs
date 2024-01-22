using Domain.Models.Usuarios;

namespace Domain.Ports.Driving.Usuarios
{
    public interface IObterUsuario
    {
        Task<IEnumerable<Usuario>> Executar();
        Task<Usuario?> Executar(int usuarioId);
    }
}
