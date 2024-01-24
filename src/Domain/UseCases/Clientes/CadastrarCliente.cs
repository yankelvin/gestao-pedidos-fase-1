using Domain.Models.Clientes;
using Domain.Ports.Driven.Clientes;
using Domain.Ports.Driving.Clientes;

namespace Domain.UseCases.Clientes;

public class CadastrarCliente : ICadastrarCliente
{
    private readonly IClientePersistenceAdapterPort _clientePersistenceAdapterPort;

    public CadastrarCliente(IClientePersistenceAdapterPort clientePersistenceAdapterPort)
    {
        _clientePersistenceAdapterPort = clientePersistenceAdapterPort;
    }

    public async Task Executar(Cliente cliente)
    {
        if (_clientePersistenceAdapterPort.ExistePorCpf(cliente.CPF))
            throw new ArgumentException("Usuário já cadastrado");
        
        await _clientePersistenceAdapterPort.InserirAsync(cliente);
    }
}