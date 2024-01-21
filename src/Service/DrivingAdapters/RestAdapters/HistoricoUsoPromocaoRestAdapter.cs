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
        private readonly ICadastrarHistoricoUsoPromocao _cadastrarHistoricoUsoPromocao1;

        public HistoricoUsoPromocaoRestAdapter(IMapper mapper, ICadastrarHistoricoUsoPromocao cadastrarHistoricoUsoPromocao)
        {
            _mapper = mapper;
            _cadastrarHistoricoUsoPromocao1 = cadastrarHistoricoUsoPromocao;
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
            await _cadastrarHistoricoUsoPromocao1.Executar(historicoUsoPromocao);
        }
    }
}
