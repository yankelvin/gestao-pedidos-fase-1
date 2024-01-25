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
    
    public Status Executar(int idPedido)
    {
        var pedido = _pedidoPersistenceAdapter.Obter(idPedido);

        pedido.Status = ProximoEtapaStatus(pedido.Status);
        
        if (pedido.Status is Status.Pronto)
            pedido.HorarioFim = DateTime.Now;
        
        _pedidoPersistenceAdapter.Atualizar(pedido);

        return pedido.Status;
    }

    private Status ProximoEtapaStatus(Status status)
    {
        if (status is Status.Recolhido)
            return Status.Recolhido;

        var statusAtual = (int)status; 
        
        return (Status)(statusAtual + 1);
    }
}