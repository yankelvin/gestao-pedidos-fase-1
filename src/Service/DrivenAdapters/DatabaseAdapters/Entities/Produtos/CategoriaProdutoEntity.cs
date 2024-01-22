using System.ComponentModel.DataAnnotations.Schema;
using Service.DrivenAdapters.DataBaseAdapters.Entities;

namespace Service.DrivenAdapters.DatabaseAdapters.Entities.Produtos
{
    [Table("categoriaproduto")]
    public class CategoriaProdutoEntity : Entity
    {
        public string Nome { get; set; }
    }
}
