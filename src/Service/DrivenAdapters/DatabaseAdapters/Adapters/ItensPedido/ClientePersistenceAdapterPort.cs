using AutoMapper;
using Domain.Ports.Driven.ItensPedido;
using Service.DrivenAdapters.DataBaseAdapters.Entities.ItensPedido;

namespace Service.DrivenAdapters.DatabaseAdapters.Adapters.ItensPedido;

public class ItensPedidoPersistenceAdapterPort : IItensPedidoPersistenceAdapterPort
{
    private readonly IMapper _mapper;
    private readonly ItensPedidoContext _itensPedidoContext;

    public ItensPedidoPersistenceAdapterPort(ItensPedidoContext itensPedidoContext, IMapper mapper)
    {
        _itensPedidoContext = itensPedidoContext;
        _mapper = mapper;
    }

    public void Insert(int pedidoId, IEnumerable<int> produtoList)
    {
        IEnumerable<ItensPedidoEntity> entity = produtoList.Select(MapItensPedido(pedidoId));
        _itensPedidoContext.ItensPedido.AddRange(entity);
    }

    public void SaveChanges()
    {
        _itensPedidoContext.SaveChanges();
    }

    private static Func<int, ItensPedidoEntity> MapItensPedido(int pedidoId)
    {
        return idProduto => new ItensPedidoEntity()
        {
            IdPedido = pedidoId,
            IdProduto = idProduto
        };
    }
}