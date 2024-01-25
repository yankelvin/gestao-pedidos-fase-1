namespace Domain.Models.Produtos
{
    public class Produto : Modelo
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public bool Status { get; private set; }
        public int IdCategoria { get; private set; }
        public virtual CategoriaProduto Categoria { get; private set; }

        public Produto(int id, string nome, bool status, int idCategoria, decimal preco)
        {
            Id = id;
            Nome = nome;
            Status = status;
            Preco = preco;
            IdCategoria = idCategoria;
        }
    }
}
