using Domain.Models.Pedidos;
using Domain.Ports.Driven.Pedidos;
using Domain.Ports.Driving.Pedidos;

namespace Domain.UseCases.Pedidos;

public class AtualizarPedido : IAtualizarPedido
{
    private readonly IPedidoPersistenceAdapterPort _pedidoPersistenceAdapter;
    
    public AtualizarPedido(IPedidoPersistenceAdapterPort pedidoPersistenceAdapter)
    {
        _pedidoPersistenceAdapter = pedidoPersistenceAdapter;
    }


    public bool Executar(Pedido pedido)
    {
        return _pedidoPersistenceAdapter.Atualizar(pedido);
    }
}