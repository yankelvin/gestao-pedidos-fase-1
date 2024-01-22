using AutoMapper;
using Domain.Models.Promocoes;
using Domain.Ports.Driving.Promocoes;
using Microsoft.AspNetCore.Mvc;
using Service.DrivingAdapters.RestAdapters.DTOs;
using System.Net.Mime;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Service.DrivingAdapters.RestAdapters
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/historico-uso-promocao")]
    public class HistoricoUsoPromocaoRestAdapter : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICadastrarHistoricoUsoPromocao _cadastrarHistoricoUsoPromocao;
        private readonly IObterHistoricoUsoPromocao _obterHistoricoUsoPromocao;

        public HistoricoUsoPromocaoRestAdapter(IMapper mapper, ICadastrarHistoricoUsoPromocao cadastrarHistoricoUsoPromocao,
                                               IObterHistoricoUsoPromocao obterHistoricoUsoPromocao)
        {
            _mapper = mapper;
            _cadastrarHistoricoUsoPromocao = cadastrarHistoricoUsoPromocao;
            _obterHistoricoUsoPromocao = obterHistoricoUsoPromocao;
        }

        /// <summary>
        /// Cadastrar historico uso promocao
        /// </summary>
        /// <response code="200">OK, Historico Uso Promocao cadastrado</response>
        /// <response code="500">Erro ao cadastrar Historico Uso Promocao</response>
        [HttpPost]
        [ProducesResponseType(typeof(HistoricoUsoPromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] HistoricoUsoPromocaoDTO historicoUsoPromocaoDTO)
        {
            var historicoUsoPromocao = _mapper.Map<HistoricoUsoPromocao>(historicoUsoPromocaoDTO);
            await _cadastrarHistoricoUsoPromocao.Executar(historicoUsoPromocao);
        }

        /// <summary>
        /// Obter historico uso promocao por id do cliente
        /// </summary>
        /// <param name="clienteId" example="432">Identificador do cliente para buscar</param>
        /// <response code="200">OK, Historico consultado</response>
        /// <response code="404">Historico nao encontrado</response>
        [HttpGet("{clienteId:int:required}")]
        [ProducesResponseType(typeof(HistoricoUsoPromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<HistoricoUsoPromocaoDTO>> Get(int clienteId)
        {
            var historico = await _obterHistoricoUsoPromocao.Executar(clienteId);
            return _mapper.Map<IEnumerable<HistoricoUsoPromocaoDTO>>(historico);
        }
    }
}
