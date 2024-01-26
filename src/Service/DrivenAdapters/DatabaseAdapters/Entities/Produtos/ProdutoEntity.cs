using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Service.DrivenAdapters.DataBaseAdapters.Entities;

namespace Service.DrivenAdapters.DatabaseAdapters.Entities.Produtos
{
    [Table("produto")]
    public class ProdutoEntity : Entity
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }
        public int IdCategoria { get; set; }
    }
}
