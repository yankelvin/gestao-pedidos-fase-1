using Domain.Models.Usuarios;

namespace Domain.Ports.Driven.Usuarios
{
    public interface IUsuarioPersistencePort
    {
        Task<IEnumerable<Usuario>> Obter();
        Task<Usuario?> Obter(int usuarioId);
        Task Cadastrar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Remover(int usuarioId);
    }
}
