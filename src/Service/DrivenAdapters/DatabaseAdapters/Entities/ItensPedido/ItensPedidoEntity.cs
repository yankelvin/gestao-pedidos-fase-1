using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Service.DrivenAdapters.DataBaseAdapters.Entities.ItensPedido;

[Table("item_pedido")]
[PrimaryKey(nameof(IdPedido), nameof(IdProduto))]
public class ItensPedidoEntity
{
    public int IdPedido { get; set; }
    public int IdProduto { get; set; }
}