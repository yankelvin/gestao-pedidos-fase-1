using Domain.Models.Usuarios;
using Domain.Ports.Driven.Usuarios;
using Domain.Ports.Driving.Usuarios;

namespace Domain.UseCases.Usuarios
{
    public class ObterUsuario : IObterUsuario
    {
        private readonly IUsuarioPersistencePort _usuarioPersistencePort;

        public ObterUsuario(IUsuarioPersistencePort usuarioPersistencePort)
        {
            _usuarioPersistencePort = usuarioPersistencePort;
        }

        public Task<IEnumerable<Usuario>> Executar()
        {
            return _usuarioPersistencePort.Obter();
        }

        public Task<Usuario?> Executar(int usuarioId)
        {
            return _usuarioPersistencePort.Obter(usuarioId);
        }
    }
}
