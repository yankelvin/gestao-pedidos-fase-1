﻿using Domain.Models.Produtos;

namespace Domain.Models.Promocoes
{
    public class ItemPromocao
    {
        public int IdPromocao { get; private set; }
        public int IdProduto { get; private set; }
        public decimal Desconto { get; private set; }

        public virtual Promocao Promocao { get; private set; }
        public virtual Produto Produto { get; private set; }

        public ItemPromocao(int idPromocao, int idProduto, decimal desconto)
        {
            IdPromocao = idPromocao;
            IdProduto = idProduto;
            Desconto = desconto;
        }

        public decimal ObterPrecoComDesconto()
        {
            if (Desconto < 1)
                return Convert.ToDecimal(Produto.Preco) - Convert.ToDecimal(Produto.Preco) * Desconto;

            return Convert.ToDecimal(Produto.Preco) - Desconto;
        }
    }
}
