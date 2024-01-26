using Domain.Models.Pedidos;

namespace Domain.Ports.Driving.Pedidos;

public interface ICadastrarPedido
{
    Task ExecutarAsync(int idCliente, IEnumerable<int> produtoList);
}