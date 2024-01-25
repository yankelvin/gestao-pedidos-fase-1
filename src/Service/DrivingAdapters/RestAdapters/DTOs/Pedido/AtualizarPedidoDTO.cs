using Domain.Enumerators;

namespace Service.DrivingAdapters.RestAdapters.DTOs.Pedido;

public class AtualizarPedidoDTO
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public Status Status { get; set; }
    public int IdCliente { get; set;}
    public DateTime HorarioInicio { get; set; }
    public DateTime HorarioFim { get; set; }
    public decimal ValorPedido { get; set; }
}