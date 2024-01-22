using AutoMapper;
using System.Net.Mime;
using Domain.Models.Produtos;
using Microsoft.AspNetCore.Mvc;
using Domain.Ports.Driving.Produtos;
using Service.DrivingAdapters.RestAdapters.DTOs;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Service.DrivingAdapters.RestAdapters
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/produtos")]
    public class ProdutoRestAdapter : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IObterProduto _obterProduto;
        private readonly IRemoverProduto _removerProduto;
        private readonly ICadastrarProduto _cadastrarProduto;
        private readonly IAtualizarProduto _atualizarProduto;

        public ProdutoRestAdapter(IMapper mapper, ICadastrarProduto cadastrarProduto, IObterProduto obterProduto)
        {
            _mapper = mapper;
            _cadastrarProduto = cadastrarProduto;
            _obterProduto = obterProduto;
        }

        /// <summary>
        /// Obter produto por id
        /// </summary>
        /// <param name="produtoId" example="54322345-5432-2345-5432-543223455432">Identificador do produto para buscar</param>
        /// <response code="200">OK, Produto consultado</response>
        /// <response code="404">Produto nao encontrado</response>
        [HttpGet("{produtoId:int:required}")]
        [ProducesResponseType(typeof(ProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<ProdutoDTO> Get(int produtoId)
        {
            Produto produto = await _obterProduto.Executar(produtoId);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        /// <summary>
        /// Obter produtos por id da categoria
        /// </summary>
        /// <param name="categoriaId" example="432">Identificador da categoria para buscar</param>
        /// <response code="200">OK, Produtos por categoria consultado</response>
        /// <response code="404">Produtos nao encontrados para categoria</response>
        [HttpGet("categoria/{categoriaId:int:required}")]
        [ProducesResponseType(typeof(ProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<ProdutoDTO>> GetPorCategoria(int categoriaId)
        {
            var produtos = await _obterProduto.ExecutarPorCategoria(categoriaId);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        /// <summary>
        /// Cadastrar produto
        /// </summary>
        /// <response code="200">OK, produto cadastrada</response>
        /// <response code="500">Erro ao cadastrar produto</response>
        [HttpPost]
        [ProducesResponseType(typeof(ProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            await _cadastrarProduto.Executar(produto);
        }

        /// <summary>
        /// Atualizar produto
        /// </summary>
        /// <response code="200">OK, Produto atualizado</response>
        /// <response code="500">Erro ao atualizar produto</response>
        [HttpPut]
        [ProducesResponseType(typeof(ProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Put([FromBody] ProdutoDTO promocaoDTO)
        {
            var produto = _mapper.Map<Produto>(promocaoDTO);
            await _atualizarProduto.Executar(produto);
        }

        /// <summary>
        /// Remover produto
        /// </summary>
        /// <response code="200">OK, Produto removido</response>
        /// <response code="500">Erro ao remover produto</response>
        [HttpDelete("{produtoId:int:required}")]
        [ProducesResponseType(typeof(ProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Delete(int produtoId)
        {
            await _removerProduto.Executar(produtoId);
        }
    }
}
