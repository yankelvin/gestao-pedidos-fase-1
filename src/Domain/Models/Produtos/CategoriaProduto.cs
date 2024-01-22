namespace Domain.Models.Produtos
{
    public class CategoriaProduto : Modelo
    {
        public string Nome { get; private set; }
        public virtual IEnumerable<Produto>? Produtos { get; private set; }
    }
}
