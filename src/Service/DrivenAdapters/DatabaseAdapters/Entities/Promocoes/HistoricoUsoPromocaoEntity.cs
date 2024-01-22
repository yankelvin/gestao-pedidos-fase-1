using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes
{
    [Table("historico_uso_promocao")]
    [PrimaryKey(nameof(idpromocao), nameof(idcliente))]
    public class HistoricoUsoPromocaoEntity
    {
        public int idpromocao { get; set; }
        public int idcliente { get; set; }
        public bool utilizado { get; set; }
    }
}
