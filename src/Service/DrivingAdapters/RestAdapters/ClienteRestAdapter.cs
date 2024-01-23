using AutoMapper;
using Domain.Models.Clientes;
using Domain.Ports.Driving.Clientes;
using Microsoft.AspNetCore.Mvc;
using Service.DrivingAdapters.RestAdapters.DTOs.Cliente;

namespace Service.DrivingAdapters.RestAdapters;

public class ClienteRestAdapter : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IObterCliente _obterCliente;
    private readonly ICadastrarCliente _cadastrarCliente;
    private readonly IAtualizarCliente _atualizarCliente;
    private readonly IDeletarCliente _deletarCliente;

    public ClienteRestAdapter(
        IMapper mapper, 
        IObterCliente obterCliente, 
        ICadastrarCliente cadastrarCliente,
        IAtualizarCliente atualizarCliente,
        IDeletarCliente deletarCliente
    )
    {
        _mapper = mapper;
        _obterCliente = obterCliente;
        _cadastrarCliente = cadastrarCliente;
        _atualizarCliente = atualizarCliente;
        _deletarCliente = deletarCliente;
    }
    
    /// <summary>
    /// Cadastro dos dados do cliente caso não esteja cadastrado
    /// </summary>
    /// <param name="dto"></param>
    /// <response code="200">Cliente cadastrado</response>
    /// <response code="400">Dados inválidos</response>
    /// <response code="409">Cliente já cadastrado</response>
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Post([FromBody] CadastroClienteDto dto)
    {
        var cliente = _mapper.Map<Cliente>(dto);

        await _cadastrarCliente.Executar(cliente);
        
        return Ok("Cliente Cadastrado");
    }
    
    /// <summary>
    /// Obtém os dados do cliente por CPF
    /// </summary>
    /// <param name="cpf"></param>
    /// <response code="200">Dados do cliente encontrado</response>
    /// <response code="404">Cliente não encontrado</response>
    [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ClienteDTO> Get([FromQuery] string cpf)
    {
        var cliente = await _obterCliente.Executar(cpf);
        return _mapper.Map<ClienteDTO>(cliente);
    }

    /// <summary>
    /// Delete do cliente por id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Cliente deletado</response>
    /// <response code="404">Cliente não encontrado</response>
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete([FromBody] int id)
    {
        await _deletarCliente.Executar(id);

        return Ok("Cliente deletado");
    }
    
    /// <summary>
    /// Update dos dados cliente
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Cliente atualizado</response>
    /// <response code="400">Dados inválidos</response>
    /// <response code="404">Cliente não encontrado</response>
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] UpdateClienteDTO dto)
    {
        var cliente = _mapper.Map<Cliente>(dto);
        await _atualizarCliente.Executar(cliente);

        return Ok("Cliente atualizado");
    }
}