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
        /// <param name="promocaoId" example="54322345-5432-2345-5432-543223455432">Identificador do produto para buscar</param>
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
    }
}
