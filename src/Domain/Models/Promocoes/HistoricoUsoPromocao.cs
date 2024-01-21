using Domain.Models.Clientes;

namespace Domain.Models.Promocoes
{
    public class HistoricoUsoPromocao
    {
        public int IdPromocao { get; private set; }
        public int IdCliente { get; private set; }
        public bool Utilizado { get; private set; }

        public Promocao Promocao { get; private set; }
        public Cliente Cliente { get; private set; }

        public HistoricoUsoPromocao(int idPromocao, int idCliente, bool utilizado)
        {
            IdPromocao = idPromocao;
            IdCliente = idCliente;
            Utilizado = utilizado;
        }
    }
}
