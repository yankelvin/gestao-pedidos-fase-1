using Domain.Ports.Driven.Pedidos;

namespace Domain.UseCases.Pedidos;

public class DeletarPedido : IDeletarPedido
{
    private readonly IPedidoPersistenceAdapterPort _pedidoPersistenceAdapter;
    
    public DeletarPedido(IPedidoPersistenceAdapterPort pedidoPersistenceAdapter)
    {
        _pedidoPersistenceAdapter = pedidoPersistenceAdapter;
    }
    
    public bool Executar(int id)
    {
        return _pedidoPersistenceAdapter.Deletar(id);
    }
}