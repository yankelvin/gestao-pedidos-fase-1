namespace Domain.Models.Clientes
{
    public class Cliente : Modelo
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public DateTime Aniversario { get; private set; }
    }
}
