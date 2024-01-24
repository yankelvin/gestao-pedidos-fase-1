using Domain.Models.Clientes;
using Domain.Ports.Driven.Clientes;
using Domain.Ports.Driving.Clientes;

namespace Domain.UseCases.Clientes;

public class ObterCliente : IObterCliente
{
    private readonly IClientePersistenceAdapterPort _clientePersistenceAdapterPort;

    public ObterCliente(IClientePersistenceAdapterPort clientePersistenceAdapterPort)
    {
        _clientePersistenceAdapterPort = clientePersistenceAdapterPort;
    }

    public Cliente? Executar(string cpf)
    {
        return _clientePersistenceAdapterPort.ObterPorCpf(cpf);
    }
}