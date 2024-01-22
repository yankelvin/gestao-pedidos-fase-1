namespace Domain.Models.Promocoes
{
    public class Promocao : Modelo
    {
        public string Texto { get; private set; }
        public bool Status { get; private set; }

        public Promocao(string texto, bool status)
        {
            Texto = texto;
            Status = status;
        }

        public Promocao(int id, string texto, bool status)
        {
            Id = id;
            Texto = texto;
            Status = status;
        }

        public void AlterarTexto(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                throw new ArgumentException("Texto da promocao nao pode ser nulo e nem vazio.");

            Texto = texto;
        }

        public void AlterarStatus(bool status)
        {
            Status = status;
        }
    }
}
