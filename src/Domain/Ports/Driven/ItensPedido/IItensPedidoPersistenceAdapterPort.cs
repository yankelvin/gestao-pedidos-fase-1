namespace Domain.Ports.Driven.ItensPedido;

public interface IItensPedidoPersistenceAdapterPort
{
    void Insert(int pedidoId, IEnumerable<int> produtoList);
    void SaveChanges();
}