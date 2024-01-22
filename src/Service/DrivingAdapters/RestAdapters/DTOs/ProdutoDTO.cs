namespace Service.DrivingAdapters.RestAdapters.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; }
        public int IdCategoria { get; private set; }
    }

    public class CategoriaProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
    }
}
