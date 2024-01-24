using AutoMapper;
using Domain.Models.Clientes;
using Domain.Ports.Driven.Clientes;
using Service.DrivenAdapters.DataBaseAdapters.Entities.Clientes;

namespace Service.DrivenAdapters.DatabaseAdapters.Adapters.Clientes;

public class ClientePersistenceAdapterPort : IClientePersistenceAdapterPort
{
    private readonly IMapper _mapper;
    private readonly ClienteContext _clienteContext;

    public Cliente? Obter(int id)
    {
         var entity = ObterSemMapear(id);
         
         if (entity is null)
             return null;
        
         return _mapper.Map<Cliente>(entity);
    }
    
    public ClienteEntity? ObterSemMapear(int id) => _clienteContext.Clientes.Find(id);

    public Cliente? ObterPorCpf(string cpf)
    {
        var entity = _clienteContext.Clientes.FirstOrDefault(c => c.CPF.Equals(cpf));

        if (entity is null)
            return null;
        
        return _mapper.Map<Cliente>(entity);
    }

    public bool Existe(int id) => Obter(id) is not null; 

    public bool ExistePorCpf(string cpf) => ObterPorCpf(cpf) is not null;
    
    public async Task InserirAsync(Cliente cliente)
    {
        var entity = _mapper.Map<ClienteEntity>(cliente);
        await _clienteContext.Clientes.AddAsync(entity);        
    }

    public bool Deletar(int id)
    {
        var entity = ObterSemMapear(id);

        if (entity is null) 
            return false;
        
        _clienteContext.Clientes.Remove(entity);
        return true;
    }

    public bool Atualizar(Cliente cliente)
    {
        var entity = ObterSemMapear(cliente.Id);

        if (entity is null) 
            return false;
        
        _clienteContext.Update(cliente);
        return true;
    }
}