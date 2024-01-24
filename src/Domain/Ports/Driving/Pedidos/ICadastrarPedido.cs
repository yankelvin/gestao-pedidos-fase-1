using Domain.Models.Pedidos;

namespace Domain.Ports.Driving.Pedidos;

public interface ICadastrarPedido
{
    void Executar(Pedido pedido, IEnumerable<int> produtoList);
}