using Domain.Enumerators;
using Domain.Models.Pedidos;

namespace Domain.Ports.Driven.Pedidos;

public interface IPedidoPersistenceAdapterPort
{
    void Inserir(Pedido pedido, IEnumerable<int> produtos);
    Pedido Obter(int id);
    bool Deletar(int id);
    bool Atualizar(Pedido pedido);
    IEnumerable<Pedido> ObterPorCliente(int? idCliente);
    public void SaveChanges();
    IEnumerable<Pedido> ObterTodosPedidos(int? idCliente, Status? statusPedido);
}