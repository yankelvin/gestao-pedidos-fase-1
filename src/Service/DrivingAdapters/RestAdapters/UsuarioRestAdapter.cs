using AutoMapper;
using System.Net.Mime;
using Domain.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Domain.Ports.Driving.Usuarios;
using Service.DrivingAdapters.RestAdapters.DTOs;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Service.DrivingAdapters.RestAdapters
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/usuario")]
    public class UsuarioRestAdapter : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IObterUsuario _obterUsuario;
        private readonly IRemoverUsuario _removerUsuario;
        private readonly ICadastrarUsuario _cadastrarUsuario;
        private readonly IAtualizarUsuario _atualizarUsuario;

        public UsuarioRestAdapter(
            IMapper mapper,
            IObterUsuario obterUsuario,
            IRemoverUsuario removerUsuario,
            ICadastrarUsuario cadastrarUsuario,
            IAtualizarUsuario atualizarUsuario
            )
        {
            _mapper = mapper;
            _obterUsuario = obterUsuario;
            _removerUsuario = removerUsuario;
            _cadastrarUsuario = cadastrarUsuario;
            _atualizarUsuario = atualizarUsuario;
        }

        /// <summary>
        /// Obter usuarios
        /// </summary>
        /// <response code="200">OK, Usuarios consultados</response>
        /// <response code="404">Usuarios nao encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(UsuarioDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<UsuarioDTO>> Get()
        {
            var usuario = await _obterUsuario.Executar();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuario);
        }


        /// <summary>
        /// Obter usuario por id
        /// </summary>
        /// <param name="usuarioId" example="54322345-5432-2345-5432-543223455432">Identificador do usuario para buscar</param>
        /// <response code="200">OK, Usuario consultado</response>
        /// <response code="404">Usuario nao encontrado</response>
        [HttpGet("{usuarioId:int:required}")]
        [ProducesResponseType(typeof(UsuarioDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<UsuarioDTO> Get(int usuarioId)
        {
            var usuario = await _obterUsuario.Executar(usuarioId);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        /// <summary>
        /// Cadastrar usuario
        /// </summary>
        /// <response code="200">OK, usuario cadastrado</response>
        /// <response code="500">Erro ao cadastrar usuario</response>
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            await _cadastrarUsuario.Executar(usuario);
        }

        /// <summary>
        /// Atualizar usuario
        /// </summary>
        /// <response code="200">OK, Usuario atualizado</response>
        /// <response code="500">Erro ao atualizar usuario</response>
        [HttpPut]
        [ProducesResponseType(typeof(UsuarioDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Put([FromBody] UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            await _atualizarUsuario.Executar(usuario);
        }

        /// <summary>
        /// Remover usuario
        /// </summary>
        /// <response code="200">OK, usuario removido</response>
        /// <response code="500">Erro ao remover usuario</response>
        [HttpDelete("{usuarioId:int:required}")]
        [ProducesResponseType(typeof(UsuarioDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Delete(int usuarioId)
        {
            await _removerUsuario.Executar(usuarioId);
        }
    }
}
