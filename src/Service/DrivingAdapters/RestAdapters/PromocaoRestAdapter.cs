using AutoMapper;
using Domain.Models.Promocoes;
using Domain.Ports.Driving.Promocoes;
using Microsoft.AspNetCore.Mvc;
using Service.DrivingAdapters.RestAdapters.DTOs;
using System.Net.Mime;
using Domain.Ports.Driven.Promocoes;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Service.DrivingAdapters.RestAdapters
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/promocoes")]
    public class PromocaoRestAdapter : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IObterPromocao _obterPromocao;
        private readonly ICadastrarPromocao _cadastrarPromocao;
        private readonly IAtualizarPromocao _atualizarPromocao;
        private readonly IRemoverPromocao _removerPromocao;
        private readonly IRegistrarUsoPromocao _registrarUsoPromocao;

        public PromocaoRestAdapter(IMapper mapper, ICadastrarPromocao cadastrarPromocao, IObterPromocao obterPromocao,
                                 IAtualizarPromocao atualizarPromocao, IRemoverPromocao removerPromocao, IRegistrarUsoPromocao registrarUsoPromocao)
        {
            _mapper = mapper;
            _obterPromocao = obterPromocao;
            _cadastrarPromocao = cadastrarPromocao;
            _atualizarPromocao = atualizarPromocao;
            _removerPromocao = removerPromocao;
            _registrarUsoPromocao = registrarUsoPromocao;
        }

        /// <summary>
        /// Obter promocao por id
        /// </summary>
        /// <param name="promocaoId" example="432">Identificador da promocao para buscar</param>
        /// <response code="200">OK, Promocao consultada</response>
        /// <response code="404">Promocao nao encontrada</response>
        [HttpGet("{promocaoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<PromocaoDTO> Get(int promocaoId)
        {
            var promocao = await _obterPromocao.Executar(promocaoId);
            return _mapper.Map<PromocaoDTO>(promocao);
        }

        /// <summary>
        /// Obter promocoes
        /// </summary>
        /// <response code="200">OK, Promocao consultada</response>
        /// <response code="404">Promocao nao encontrada</response>
        [HttpGet]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<PromocaoDTO>> Get()
        {
            var promocoes = await _obterPromocao.Executar();
            return _mapper.Map<IEnumerable<PromocaoDTO>>(promocoes);
        }

        /// <summary>
        /// Cadastrar promocao
        /// </summary>
        /// <response code="200">OK, Promocao cadastrada</response>
        /// <response code="500">Erro ao cadastrar promocao</response>
        [HttpPost]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] PromocaoDTO promocaoDTO)
        {
            var promocao = _mapper.Map<Promocao>(promocaoDTO);
            await _cadastrarPromocao.Executar(promocao);
        }

        /// <summary>
        /// Atualizar promocao
        /// </summary>
        /// <response code="200">OK, Promocao atualizada</response>
        /// <response code="500">Erro ao atualizar promocao</response>
        [HttpPut]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Put([FromBody] PromocaoDTO promocaoDTO)
        {
            var promocao = _mapper.Map<Promocao>(promocaoDTO);
            await _atualizarPromocao.Executar(promocao);
        }

        /// <summary>
        /// Remover promocao
        /// </summary>
        /// <response code="200">OK, Promocao removida</response>
        /// <response code="500">Erro ao remover promocao</response>
        [HttpDelete("{promocaoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Delete(int promocaoId)
        {
            await _removerPromocao.Executar(promocaoId);
        }
        
        /// <summary>
        /// Register uso da promoçao pelo cliente
        /// </summary>
        /// <response code="200">Uso registrado</response>
        [HttpPost("{clienteId:int:required}/{promocaoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<ActionResult> RegistrarUsoPromocao(int clienteId, int promocaoId)
        {
            try
            {
                await _registrarUsoPromocao.Executar(clienteId, promocaoId);
                return Ok("Registrado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
