using Domain.Enumerators;
using Domain.Models.Pedidos;
using Domain.Ports.Driven.Pedidos;
using Domain.Ports.Driving.Pedidos;

namespace Domain.UseCases.Pedidos;

public class ObterTodosPedidos : IObterTodosPedidos
{
    private readonly IPedidoPersistenceAdapterPort _pedidoPersistenceAdapter;
    
    public ObterTodosPedidos(IPedidoPersistenceAdapterPort pedidoPersistenceAdapter)
    {
        _pedidoPersistenceAdapter = pedidoPersistenceAdapter;
    }
    
    public IEnumerable<Pedido> Executar(int? idCliente, Status? statusPedido)
    {
        return _pedidoPersistenceAdapter.ObterTodosPedidos(idCliente, statusPedido);
    }
}