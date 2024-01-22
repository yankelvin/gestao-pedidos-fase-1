using Domain.Models.Usuarios;
using Domain.Ports.Driven.Usuarios;
using Domain.Ports.Driving.Usuarios;

namespace Domain.UseCases.Usuarios
{
    public class CadastrarUsuario : ICadastrarUsuario
    {
        private readonly IUsuarioPersistencePort _usuarioPersistencePort;

        public CadastrarUsuario(IUsuarioPersistencePort usuarioPersistencePort)
        {
            _usuarioPersistencePort = usuarioPersistencePort;
        }

        public async Task Executar(Usuario usuario)
        {
            await _usuarioPersistencePort.Cadastrar(usuario);
        }
    }
}
