using Domain.Enumerators;

namespace Service.DrivingAdapters.RestAdapters.DTOs.Pedido;

public class AtualizarPedidoDTO
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public StatusPedido StatusPedido { get; set; }
    public int IdCliente { get; set;}
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFim { get; set; }
    public decimal ValorPedido { get; set; }
}