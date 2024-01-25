using System.Net.Mime;
using AutoMapper;
using Domain.Enumerators;
using Domain.Models.Pedidos;
using Domain.Ports.Driven.Pedidos;
using Domain.Ports.Driving.Pedidos;
using Microsoft.AspNetCore.Mvc;
using Service.DrivingAdapters.RestAdapters.DTOs.Pedido;

namespace Service.DrivingAdapters.RestAdapters;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/pedido")]
public class PedidoRestAdapter : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICadastrarPedido _cadastrarPedido;
    private readonly IObterPedido _obterPedido;
    private readonly IObterTodosPedidos _obterTodosPedidos;
    private readonly IDeletarPedido _deletarPedido;
    private readonly IAtualizarPedido _atualizarPedido;
    private readonly IProximaEtapaPedido _proximaEtapaPedido;

    public PedidoRestAdapter(
        IMapper mapper, ICadastrarPedido cadastrarPedido, IObterPedido obterPedido, IObterTodosPedidos obterTodosPedidos, IDeletarPedido deletarPedido, IAtualizarPedido atualizarPedido, IProximaEtapaPedido proximaEtapaPedido)
    {
        _mapper = mapper;
        _cadastrarPedido = cadastrarPedido;
        _obterPedido = obterPedido;
        _obterTodosPedidos = obterTodosPedidos;
        _deletarPedido = deletarPedido;
        _atualizarPedido = atualizarPedido;
        _proximaEtapaPedido = proximaEtapaPedido;
    }
    
    /// <summary>
    /// Cadastro do pedido
    /// </summary>
    /// <param name="dto"></param>
    /// <response code="200">Pedido cadastrado</response>
    [HttpPost]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<ActionResult> Post([FromBody] CadastroPedidoDto dto)
    {
        try
        {
            await _cadastrarPedido.ExecutarAsync(dto.IdCliente, dto.Produtos);
            return Ok("Pedido Cadastrado");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
    
    /// <summary>
    /// Obtém os dados do pedido por id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Dados do cliente encontrado</response>
    /// <response code="404">Cliente não encontrado</response>
    [HttpGet("{id:int:required}")]
    [ProducesResponseType(typeof(PedidoDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<PedidoDTO> Get( int id)
    {
        var pedido = _obterPedido.Executar(id);

        if (pedido is null)
            return NotFound("Pedido não encontrado");
        
        return _mapper.Map<PedidoDTO>(pedido);
    }
    
    /// <summary>
    /// Obtém os todos os pedidos ou lista os pedidos do cliente
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Lista de pedidos</response>
    [HttpGet("get-all")]
    [ProducesResponseType(typeof(IEnumerable<PedidoDTO>), StatusCodes.Status200OK)]
    public IEnumerable<PedidoDTO> GetAll([FromQuery] int? idCliente, Status? statusPedido)
    {
        var listaPedidos = _obterTodosPedidos.Executar(idCliente, statusPedido);
        
        return _mapper.Map<IEnumerable<PedidoDTO>>(listaPedidos);
    }

    /// <summary>
    /// Delete pedido por id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Pedido deletado</response>
    /// <response code="404">Pedido não encontrado</response>
    [HttpDelete("{id:int:required}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id)
    {
        var sucesso = _deletarPedido.Executar(id);
        
        if(sucesso)
            return Ok("Pedido deletado com sucesso!");

        return NotFound("Pedido não encontrado");
    }
    
    /// <summary>
    /// Update dos dados pedid
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Pedido atualizado</response>
    /// <response code="404">Pedido não encontrado</response>
    [HttpPut]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult Put([FromBody] AtualizarPedidoDTO dto)
    {
        var pedido = _mapper.Map<Pedido>(dto);
        var sucesso = _atualizarPedido.Executar(pedido);
        
        if(sucesso)
            return Ok("Pedido atualizado");

        return NotFound("Pedido não encontrado");
    }
    
    /// <summary>
    /// Próxima etapa do pedido
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Pedido atualizado</response>
    /// <response code="404">Pedido não encontrado</response>
    [HttpPost("next-step/{idPedido:int:required}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult NextStep(int idPedido)
    {
        var novoStatus = _proximaEtapaPedido.Executar(idPedido);
        
        return Ok($"Novo status do pedido {novoStatus}");
    }
}