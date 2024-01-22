using Domain.Models.Usuarios;

namespace Domain.Ports.Driving.Usuarios
{
    public interface ICadastrarUsuario
    {
        Task Executar(Usuario usuario);
    }
}
