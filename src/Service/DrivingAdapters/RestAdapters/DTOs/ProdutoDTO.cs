namespace Service.DrivingAdapters.RestAdapters.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public bool Ativo { get; set; }
        public int IdCategoria { get; set; }
    }

    public class CategoriaProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
    }
}
