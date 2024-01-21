namespace Service.DrivingAdapters.RestAdapters.DTOs
{
    public class PromocaoDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public bool Status { get; set; }
    }

    public class ItemPromocaoDTO
    {
        public int IdPromocao { get; private set; }
        public int IdProduto { get; private set; }
        public decimal Desconto { get; private set; }
    }

    public class HistoricoUsoPromocaoDTO
    {
        public int IdPromocao { get; private set; }
        public int IdCliente { get; private set; }
        public bool Utilizado { get; private set; }
    }
}
