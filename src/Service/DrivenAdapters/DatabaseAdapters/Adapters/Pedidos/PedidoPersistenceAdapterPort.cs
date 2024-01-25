using AutoMapper;
using Domain.Enumerators;
using Domain.Models.Pedidos;
using Domain.Ports.Driven.Pedidos;
using Service.DrivenAdapters.DataBaseAdapters.Entities.ItensPedido;
using Service.DrivenAdapters.DataBaseAdapters.Entities.Pedidos;

namespace Service.DrivenAdapters.DatabaseAdapters.Adapters.Pedidos;

public class PedidoPersistenceAdapterPort : IPedidoPersistenceAdapterPort
{
    private readonly IMapper _mapper;
    private readonly PedidoContext _pedidoContext;

    public PedidoPersistenceAdapterPort(IMapper mapper, PedidoContext pedidoContext)
    {
        _mapper = mapper;
        _pedidoContext = pedidoContext;
    }
    
    public void Inserir(Pedido pedido, IEnumerable<int> produtoList)
    {
        var pedidoEntity = _mapper.Map<PedidoEntity>(pedido);

        var pedidoSaved = _pedidoContext.Pedidos.Add(pedidoEntity);
        
        IEnumerable<ItensPedidoEntity> itensPedidos = produtoList.Select(MapItensPedido(pedidoSaved.Entity));

        _pedidoContext.ItensPedidos.AddRange(itensPedidos);
    }
    
    private static Func<int, ItensPedidoEntity> MapItensPedido(PedidoEntity pedido)
    {
        return idProduto => new ItensPedidoEntity()
        {
            Pedido = pedido,
            IdProduto = idProduto
        };
    }
    
    public PedidoEntity? ObterSemMapear(int id) => _pedidoContext.Pedidos.Find(id);

    public Pedido Obter(int id)
    {
        var entity = _pedidoContext.Pedidos.Find(id);

        return _mapper.Map<Pedido>(entity);
    }

    public IEnumerable<Pedido> ObterTodosPedidos(int? idCliente, Status? statusPedido)
    {
        var query = _pedidoContext
            .Pedidos
            .AsQueryable();

        if (idCliente is not null)
            query = query.Where(p => p.IdCliente.Equals(idCliente));

        if (statusPedido is not null)
            query = query.Where(p => p.Status.Equals(statusPedido));
        
        var result = query.ToList();

        return _mapper.Map<IEnumerable<Pedido>>(result);
    }

    public bool Deletar(int id)
    {
        var entity = ObterSemMapear(id);

        if (entity is null) 
            return false;
        
        _pedidoContext.Pedidos.Remove(entity);
        _pedidoContext.SaveChanges();
        return true;
    }

    public bool Atualizar(Pedido pedido)
    {
        var pedidoAnterior = ObterSemMapear(pedido.Id);

        if (pedidoAnterior is null) 
            return false;

        pedidoAnterior.IdCliente = pedido.IdCliente;
        pedidoAnterior.Status = pedido.Status;
        pedidoAnterior.HorarioInicio = pedido.HorarioInicio;
        pedidoAnterior.HorarioFim = pedido.HorarioFim;
        pedidoAnterior.ValorPedido = pedido.ValorPedido;
        
        _pedidoContext.Pedidos.Update(pedidoAnterior);
        _pedidoContext.SaveChanges();
        return true;
    }

    public IEnumerable<Pedido> ObterPorCliente(int? idCliente)
    {
        var entity = _pedidoContext
            .Pedidos
            .Where(p => p.IdCliente.Equals(idCliente))
            .ToList();

        return _mapper.Map<IEnumerable<Pedido>>(entity);
    }

    public void SaveChanges()
    {
        _pedidoContext.SaveChanges();
    }
}