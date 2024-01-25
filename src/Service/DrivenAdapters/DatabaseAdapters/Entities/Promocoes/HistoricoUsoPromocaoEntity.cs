using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes
{
    [Table("historico_uso_promocao")]
    [PrimaryKey(nameof(idPromocao), nameof(idCliente))]
    public class HistoricoUsoPromocaoEntity
    {
        public int idPromocao { get; set; }
        public int idCliente { get; set; }
        public bool utilizado { get; set; }
    }
}
