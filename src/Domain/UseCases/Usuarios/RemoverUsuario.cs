using Domain.Ports.Driven.Usuarios;
using Domain.Ports.Driving.Usuarios;

namespace Domain.UseCases.Usuarios
{
    public class RemoverUsuario : IRemoverUsuario
    {
        private readonly IUsuarioPersistencePort _usuarioPersistencePort;

        public RemoverUsuario(IUsuarioPersistencePort usuarioPersistencePort)
        {
            _usuarioPersistencePort = usuarioPersistencePort;
        }

        public async Task Executar(int usuarioId)
        {
            await _usuarioPersistencePort.Remover(usuarioId);
        }
    }
}
