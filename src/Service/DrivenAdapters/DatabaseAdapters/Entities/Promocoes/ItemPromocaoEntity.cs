using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes
{
    [Table("item_promocao")]
    [PrimaryKey(nameof(idpromocao), nameof(idproduto))]
    public class ItemPromocaoEntity
    {
        public int idpromocao { get; set; }
        public int idproduto { get; set; }
        public double desconto { get; set; }
    }
}
