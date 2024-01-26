using Domain.Models.Produtos;

namespace Domain.Models.Promocoes
{
    public class ItemPromocao
    {
        public int IdPromocao { get; private set; }
        public int IdProduto { get; private set; }
        public double Desconto { get; private set; }

        public virtual Promocao Promocao { get; private set; }
        public virtual Produto Produto { get; private set; }

        public ItemPromocao(int idPromocao, int idProduto, double desconto)
        {
            IdPromocao = idPromocao;
            IdProduto = idProduto;
            Desconto = desconto;
        }

        public double ObterPrecoComDesconto()
        {
            if (Desconto < 1)
                return Produto.Preco - Produto.Preco * Desconto;

            return Produto.Preco - Desconto;
        }
    }
}
