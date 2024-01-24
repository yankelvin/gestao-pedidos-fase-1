using Domain.Enumerators;

namespace Service.DrivingAdapters.RestAdapters.DTOs.Pedido;

public class CadastroPedidoDto
{
    public StatusPedido StatusPedido { get; set; }
    public int IdCliente { get; set;}
    public decimal ValorPedido { get; set; }
    
    public IEnumerable<int> Produtos { get; set; }
}