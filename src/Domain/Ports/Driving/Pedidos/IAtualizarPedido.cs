using Domain.Models.Pedidos;

namespace Domain.Ports.Driving.Pedidos;

public interface IAtualizarPedido
{
    bool Executar(Pedido pedido);
}