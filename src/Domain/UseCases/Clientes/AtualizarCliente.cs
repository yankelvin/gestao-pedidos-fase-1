using Domain.Models.Clientes;
using Domain.Ports.Driven.Clientes;
using Domain.Ports.Driving.Clientes;

namespace Domain.UseCases.Clientes;

public class AtualizarCliente : IAtualizarCliente
{
    private readonly IClientePersistenceAdapterPort _clientePersistenceAdapterPort;

    public AtualizarCliente(IClientePersistenceAdapterPort clientePersistenceAdapterPort)
    {
        _clientePersistenceAdapterPort = clientePersistenceAdapterPort;
    }

    public bool Executar(Cliente cliente)
    {
        if(_clientePersistenceAdapterPort.Existe(cliente.Id))
            return _clientePersistenceAdapterPort.Atualizar(cliente);

        return false;
    }
}