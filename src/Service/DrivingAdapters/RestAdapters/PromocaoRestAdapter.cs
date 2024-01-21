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
    [Route("api/promocoes")]
    public class PandasRestAdapter : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICadastrarPromocao _cadastrarPromocao;
        private readonly IObterPromocao _obterPromocao;

        public PandasRestAdapter(IMapper mapper, ICadastrarPromocao cadastrarPromocao, IObterPromocao obterPromocao)
        {
            _mapper = mapper;
            _cadastrarPromocao = cadastrarPromocao;
            _obterPromocao = obterPromocao;
        }

        /// <summary>
        /// Obter promocao por id
        /// </summary>
        /// <param name="promocaoId" example="54322345-5432-2345-5432-543223455432">Identificador da promocao para buscar</param>
        /// <response code="200">OK, Promocao consultada</response>
        /// <response code="404">Promocao nao encontrada</response>
        [HttpGet("{promocaoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<PromocaoDTO> Get(int promocaoId)
        {
            Promocao promocao = await _obterPromocao.Executar(promocaoId);
            return _mapper.Map<PromocaoDTO>(promocao);
        }
    }
}
