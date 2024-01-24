using Domain.Ports.Driven.Clientes;
using Domain.Ports.Driving.Clientes;

namespace Domain.UseCases.Clientes;

public class DeletarCliente : IDeletarCliente
{
    private readonly IClientePersistenceAdapterPort _clientePersistenceAdapterPort;

    public DeletarCliente(IClientePersistenceAdapterPort clientePersistenceAdapterPort)
    {
        _clientePersistenceAdapterPort = clientePersistenceAdapterPort;
    }

    public bool Executar(int id)
    {
        if (_clientePersistenceAdapterPort.Existe(id))
            return _clientePersistenceAdapterPort.Deletar(id);
        
        return false;
    }
}