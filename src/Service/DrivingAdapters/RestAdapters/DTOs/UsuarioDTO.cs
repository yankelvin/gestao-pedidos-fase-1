namespace Service.DrivingAdapters.RestAdapters.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Tipo { get; private set; }
        public bool Ativo { get; private set; }
    }

}
