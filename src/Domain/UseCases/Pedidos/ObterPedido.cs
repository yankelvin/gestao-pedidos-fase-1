using Domain.Models.Pedidos;
using Domain.Ports.Driven.Pedidos;
using Domain.Ports.Driving.Pedidos;

namespace Domain.UseCases.Pedidos;

public class ObterPedido : IObterPedido
{
    private readonly IPedidoPersistenceAdapterPort _persistenceAdapterPort;
    
    public ObterPedido(IPedidoPersistenceAdapterPort persistenceAdapterPort)
    {
        _persistenceAdapterPort = persistenceAdapterPort;
    }

    public Pedido Executar(int id)
    {
        return _persistenceAdapterPort.Obter(id);
    }
}