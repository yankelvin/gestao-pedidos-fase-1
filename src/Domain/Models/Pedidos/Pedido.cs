using Domain.Enumerators;

namespace Domain.Models.Pedidos;

public class Pedido : Modelo
{
    public DateTime DataPedido { get; set; }
    public StatusPedido StatusPedido { get; set; }
    public int IdCliente { get; private set;}
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFim { get; set; }
    public decimal ValorPedido { get; private set; }
}