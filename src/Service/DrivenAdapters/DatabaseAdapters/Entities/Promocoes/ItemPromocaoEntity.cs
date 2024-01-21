using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes
{
    [Table("ItemPromocao")]
    [PrimaryKey(nameof(IdPromocao), nameof(IdProduto))]
    public class ItemPromocaoEntity
    {
        public int IdPromocao { get; set; }
        public int IdProduto { get; set; }
        public decimal Desconto { get; set; }
    }
}
