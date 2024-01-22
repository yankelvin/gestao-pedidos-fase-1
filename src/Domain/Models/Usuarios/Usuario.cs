namespace Domain.Models.Usuarios
{
    public class Usuario : Modelo
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Tipo { get; private set; }
        public bool Ativo { get; private set; }

        public Usuario(int id, string nome, string email, string senha, string tipo, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Tipo = tipo;
            Ativo = ativo;
        }
    }
}
