using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enumerators;

namespace Service.DrivenAdapters.DataBaseAdapters.Entities.Pedidos;

[Table("pedido")]
public class PedidoEntity : Entity
{
    public DateTime DataPedido { get; private set; }
    public StatusPedido StatusPedido { get; private set; }
    public int IdCliente { get; private set;}
    public DateTime HoraInicio { get; private set; }
    public DateTime HoraFim { get; private set; }
    public decimal ValorPedido { get; private set; }
}