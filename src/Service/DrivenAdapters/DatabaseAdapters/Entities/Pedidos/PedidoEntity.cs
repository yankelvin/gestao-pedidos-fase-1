using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enumerators;

namespace Service.DrivenAdapters.DataBaseAdapters.Entities.Pedidos;

[Table("pedido")]
public class PedidoEntity : Entity
{
    public DateTime DataPedido { get; set; }
    public Status Status { get; set; }
    public int IdCliente { get; set;}
    public DateTime HorarioInicio { get; set; }
    public DateTime HorarioFim { get; set; }
    public decimal ValorPedido { get; set; }
}