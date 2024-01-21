using System.ComponentModel.DataAnnotations.Schema;
using Service.DrivenAdapters.DataBaseAdapters.Entities;

namespace Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes
{
    [Table("promocao")]
    public class PromocaoEntity : Entity
    {
        public string Texto { get; set; }
        public bool Status { get; set; }
    }
}
