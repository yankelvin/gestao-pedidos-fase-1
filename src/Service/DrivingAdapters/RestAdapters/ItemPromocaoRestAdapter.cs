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
    [Route("api/item-promocoes")]
    public class ItemPromocaoRestAdapter : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IObterItemPromocao _obterItemPromocao;
        private readonly ICadastrarItemPromocao _cadastrarItemPromocao;
        private readonly IAtualizarItemPromocao _atualizarItemPromocao;
        private readonly IRemoverItemPromocao _removerItemPromocao;

        public ItemPromocaoRestAdapter(IMapper mapper, ICadastrarItemPromocao cadastrarPromocao, IObterItemPromocao obterPromocao,
                                       IAtualizarItemPromocao atualizarPromocao, IRemoverItemPromocao removerPromocao)
        {
            _mapper = mapper;
            _obterItemPromocao = obterPromocao;
            _cadastrarItemPromocao = cadastrarPromocao;
            _atualizarItemPromocao = atualizarPromocao;
            _removerItemPromocao = removerPromocao;
        }

        /// <summary>
        /// Obter item promocao por id da promocao
        /// </summary>
        /// <param name="promocaoId" example="432">Identificador da item promocao para buscar</param>
        /// <response code="200">OK, Item Promocao consultada</response>
        /// <response code="404">Item Promocao nao encontrada</response>
        [HttpGet("promocao/{promocaoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<ItemPromocaoDTO>> GetPorPromocao(int promocaoId)
        {
            var itensPromocoes = await _obterItemPromocao.ExecutarPorPromocao(promocaoId);
            return _mapper.Map<IEnumerable<ItemPromocaoDTO>>(itensPromocoes);
        }

        /// <summary>
        /// Obter item promocao por id do produto
        /// </summary>
        /// <param name="produtoId" example="432">Identificador da item promocao para buscar</param>
        /// <response code="200">OK, Item Promocao consultada</response>
        /// <response code="404">Item Promocao nao encontrada</response>
        [HttpGet("produto/{produtoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<ItemPromocaoDTO>> GetPorProduto(int produtoId)
        {
            var itensPromocao = await _obterItemPromocao.ExecutarPorProduto(produtoId);
            return _mapper.Map<IEnumerable<ItemPromocaoDTO>>(itensPromocao);
        }


        /// <summary>
        /// Cadastrar item promocao
        /// </summary>
        /// <response code="200">OK, Item Promocao cadastrada</response>
        /// <response code="500">Erro ao cadastrar item promocao</response>
        [HttpPost]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] ItemPromocaoDTO promocaoDTO)
        {
            var promocao = _mapper.Map<ItemPromocao>(promocaoDTO);
            await _cadastrarItemPromocao.Executar(promocao);
        }

        /// <summary>
        /// Atualizar item promocao
        /// </summary>
        /// <response code="200">OK, item Promocao atualizado</response>
        /// <response code="500">Erro ao atualizar item promocao</response>
        [HttpPut]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Put([FromBody] ItemPromocaoDTO promocaoDTO)
        {
            var itemPromocao = _mapper.Map<ItemPromocao>(promocaoDTO);
            await _atualizarItemPromocao.Executar(itemPromocao);
        }

        /// <summary>
        /// Remover item promocao
        /// </summary>
        /// <response code="200">OK, Item Promocao removido</response>
        /// <response code="500">Erro ao remover item promocao</response>
        [HttpDelete("{promocaoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Delete(int promocaoId)
        {
            await _removerItemPromocao.Executar(promocaoId);
        }
    }
}
