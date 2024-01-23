using AutoMapper;
using Domain.Models.Clientes;
using Domain.Ports.Driven.Clientes;
using Service.DrivenAdapters.DataBaseAdapters.Entities.Clientes;

namespace Service.DrivenAdapters.DatabaseAdapters.Adapters.Clientes;

public class ClientePersistenceAdapterPort : IClientePersistenceAdapterPort
{
    private readonly IMapper _mapper;
    private readonly ClienteContext _clienteContext;
    
    
    public Cliente? FindByCpf(string cpf)
    {
        var entity = _clienteContext.Clientes.FirstOrDefault(c => c.CPF.Equals(cpf));

        if (entity is null)
            return null;
        
        return _mapper.Map<Cliente>(entity);
    }

    public bool Exists(string cpf) => FindByCpf(cpf) is not null;
    
    public async Task InsertAsync(Cliente cliente)
    {
        var entity = _mapper.Map<ClienteEntity>(cliente);
        await _clienteContext.Clientes.AddAsync(entity);        
    }
}