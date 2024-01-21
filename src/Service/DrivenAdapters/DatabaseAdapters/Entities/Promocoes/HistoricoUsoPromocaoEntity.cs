using Domain.Models.Produtos;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes
{
    [Table("HistoricoUsoPromocao")]
    [PrimaryKey(nameof(IdPromocao), nameof(IdCliente))]
    public class HistoricoUsoPromocaoEntity
    {
        public int IdPromocao { get; set; }
        public int IdCliente { get; set; }
        public bool Utilizado { get; set; }
    }
}
