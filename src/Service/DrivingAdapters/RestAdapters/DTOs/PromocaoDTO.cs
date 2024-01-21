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
        public int IdPromocao { get; set; }
        public int IdProduto { get; set; }
        public decimal Desconto { get; set; }
    }

    public class HistoricoUsoPromocaoDTO
    {
        public int IdPromocao { get; set; }
        public int IdCliente { get; set; }
        public bool Utilizado { get; set; }
    }
}
