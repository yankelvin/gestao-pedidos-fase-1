using AutoMapper;
using System.Net.Mime;
using Domain.Models.Produtos;
using Microsoft.AspNetCore.Mvc;
using Domain.Ports.Driving.Produtos;
using Service.DrivingAdapters.RestAdapters.DTOs;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Domain.UseCases.Produtos;

namespace Service.DrivingAdapters.RestAdapters
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/categoria-produtos")]
    public class CategoriaProdutoRestAdapter : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IObterCategoriaProduto _obterCategoriaProduto;
        private readonly IRemoverCategoriaProduto _removerCategoriaProduto;
        private readonly ICadastrarCategoriaProduto _cadastrarCategoriaProduto;
        private readonly IAtualizarCategoriaProduto _atualizarCategoriaProduto;

        public CategoriaProdutoRestAdapter(
            IMapper mapper,
            IObterCategoriaProduto obterCategoriaProduto,
            IRemoverCategoriaProduto removerCategoriaProduto,
            ICadastrarCategoriaProduto cadastrarCategoriaProduto,
            IAtualizarCategoriaProduto atualizarCategoriaProduto
            )
        {
            _mapper = mapper;
            _obterCategoriaProduto = obterCategoriaProduto;
            _removerCategoriaProduto = removerCategoriaProduto;
            _cadastrarCategoriaProduto = cadastrarCategoriaProduto;
            _atualizarCategoriaProduto = atualizarCategoriaProduto;
        }

        /// <summary>
        /// Obter categorias produtos
        /// </summary>
        /// <response code="200">OK, Categorias consultadas</response>
        /// <response code="404">Categorias nao encontradas</response>
        [HttpGet]
        [ProducesResponseType(typeof(CategoriaProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<CategoriaProdutoDTO>> Get()
        {
            var categorias = await _obterCategoriaProduto.Executar();
            return _mapper.Map<IEnumerable<CategoriaProdutoDTO>>(categorias);
        }

        /// <summary>
        /// Obter categoria produto por id
        /// </summary>
        /// <param name="categoriaId" example="54322345-5432-2345-5432-543223455432">Identificador da categoria para buscar</param>
        /// <response code="200">OK, Categoria contultada</response>
        /// <response code="404">Categoria nao encontrada</response>
        [HttpGet("{categoriaId:int:required}")]
        [ProducesResponseType(typeof(CategoriaProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<CategoriaProdutoDTO> Get(int categoriaId)
        {
            var categoria = await _obterCategoriaProduto.Executar(categoriaId);
            return _mapper.Map<CategoriaProdutoDTO>(categoria);
        }

        /// <summary>
        /// Cadastrar categoria
        /// </summary>
        /// <response code="200">OK, categoria cadastrada</response>
        /// <response code="500">Erro ao cadastrar categoria</response>
        [HttpPost]
        [ProducesResponseType(typeof(CategoriaProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] CategoriaProdutoDTO categoriaDTO)
        {
            var categoria = _mapper.Map<CategoriaProduto>(categoriaDTO);
            await _cadastrarCategoriaProduto.Executar(categoria);
        }

        /// <summary>
        /// Atualizar categoria
        /// </summary>
        /// <response code="200">OK, Categoria atualizada</response>
        /// <response code="500">Erro ao atualizar categoria</response>
        [HttpPut]
        [ProducesResponseType(typeof(CategoriaProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Put([FromBody] CategoriaProdutoDTO categoriaDTO)
        {
            var categoria = _mapper.Map<CategoriaProduto>(categoriaDTO);
            await _atualizarCategoriaProduto.Executar(categoria);
        }

        /// <summary>
        /// Remover categoria
        /// </summary>
        /// <response code="200">OK, Categoria removida</response>
        /// <response code="500">Erro ao remover categoria</response>
        [HttpDelete("{categoriaId:int:required}")]
        [ProducesResponseType(typeof(CategoriaProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Delete(int categoriaId)
        {
            await _removerCategoriaProduto.Executar(categoriaId);
        }
    }
}
