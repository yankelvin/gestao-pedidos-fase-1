namespace Service.DrivingAdapters.RestAdapters.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Tipo { get; set; }
        public bool Ativo { get; set; }
    }

}
