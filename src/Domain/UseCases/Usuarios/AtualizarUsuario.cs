using Domain.Models.Usuarios;
using Domain.Ports.Driven.Usuarios;
using Domain.Ports.Driving.Usuarios;

namespace Domain.UseCases.Usuarios
{
    public class AtualizarUsuario : IAtualizarUsuario
    {
        private readonly IUsuarioPersistencePort _usuarioPersistencePort;

        public AtualizarUsuario(IUsuarioPersistencePort usuarioPersistencePort)
        {
            _usuarioPersistencePort = usuarioPersistencePort;
        }

        public async Task Executar(Usuario usuario)
        {
            await _usuarioPersistencePort.Atualizar(usuario);
        }
    }
}
