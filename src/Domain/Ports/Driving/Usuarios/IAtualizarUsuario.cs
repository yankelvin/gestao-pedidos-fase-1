using Domain.Models.Usuarios;

namespace Domain.Ports.Driving.Usuarios
{
    public interface IAtualizarUsuario
    {
        Task Executar(Usuario usuario);
    }
}
