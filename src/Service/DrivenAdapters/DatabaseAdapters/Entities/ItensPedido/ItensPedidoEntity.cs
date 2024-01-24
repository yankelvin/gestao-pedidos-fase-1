using System.ComponentModel.DataAnnotations.Schema;

namespace Service.DrivenAdapters.DataBaseAdapters.Entities.ItensPedido;

[Table("item_pedido")]
public class ItensPedidoEntity
{
    public int IdPedido { get; set; }
    public int IdProduto { get; set; }
}