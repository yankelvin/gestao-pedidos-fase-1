using Domain.Exceptions;

namespace Domain.Models.Produtos
{
    public class Produto : Modelo
    {
        public string Nome { get; private set; }
        public bool Status { get; private set; }
        public decimal Preco { get; private set; }

        public Produto(string nome, bool status, decimal preco)
        {
            Nome = nome;
            Status = status;
            Preco = preco;
        }
    }
}
