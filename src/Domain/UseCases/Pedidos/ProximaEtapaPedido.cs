using Domain.Enumerators;
using Domain.Models.Pedidos;
using Domain.Ports.Driven.Pedidos;
using Domain.Ports.Driving.Pedidos;

namespace Domain.UseCases.Pedidos;

public class ProximaEtapaPedido : IProximaEtapaPedido
{ 
    private readonly IPedidoPersistenceAdapterPort _pedidoPersistenceAdapter;
    
    public ProximaEtapaPedido(IPedidoPersistenceAdapterPort pedidoPersistenceAdapter)
    {
        _pedidoPersistenceAdapter = pedidoPersistenceAdapter;
    }
    
    public StatusPedido Executar(int idPedido)
    {
        var pedido = _pedidoPersistenceAdapter.Obter(idPedido);

        pedido.StatusPedido = ProximoEtapaStatus(pedido.StatusPedido);
        
        if (pedido.StatusPedido is StatusPedido.Pronto)
            pedido.HoraFim = DateTime.Now;
        
        _pedidoPersistenceAdapter.Atualizar(pedido);

        return pedido.StatusPedido;
    }

    private StatusPedido ProximoEtapaStatus(StatusPedido statusPedido)
    {
        if (statusPedido is StatusPedido.Recolhido)
            return StatusPedido.Recolhido;
        
        var novoStatus = (int)statusPedido++;

        return (StatusPedido)novoStatus;
    }
}