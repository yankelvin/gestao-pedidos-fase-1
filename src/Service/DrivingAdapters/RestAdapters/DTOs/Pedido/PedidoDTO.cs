using Domain.Enumerators;

namespace Service.DrivingAdapters.RestAdapters.DTOs.Pedido;

public class PedidoDTO
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public Status Status { get; set; }
    public string DescricaoStatus => Status.ToString();
    public int IdCliente { get; set;}
    public DateTime HorarioInicio { get; set; }
    public DateTime HorarioFim { get; set; }
    public decimal ValorPedido { get; set; }
}