using System.ComponentModel;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class ClienteService (IPersonDataContext context):IClienteService
{
    
    public Cliente Create(Cliente cliente)
    {
        
       
        if(cliente.DataNascimento > DateTime.Now)
        {
            throw new Exception("A data de nascimento não pode ser maior que hoje");
        }

        if (cliente.DataNascimento < new DateTime(1900, 1, 1))
        {
            throw new Exception("A data de nascimento precisa ser maior que esse valor");
        }

         cliente.CPF = cliente.CPF.Replace(".", "").Replace("-", "");
         
         if (cliente.CPF.Length != 11)
         {
             throw new Exception("O CPF deve ter 11 caracteres");
         }
        
         context.Cliente.Add(cliente);
         context.SaveChanges();
         return cliente;
       
    }

    public Cliente GetByPk (int id)
    {
        try
        {
            return context.Cliente.First(x => x.Id == id);
        }
        catch(Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
        
    }


    public Cliente Update(int id, Cliente cliente)
    {
        var clienteAtualizado = GetByPk(id);
       clienteAtualizado.Nome = cliente.Nome;
       clienteAtualizado.DataNascimento = cliente.DataNascimento;
       clienteAtualizado.CPF = cliente.CPF;
        context.SaveChanges();
        return clienteAtualizado;

    }

    public Cliente Remove(int id)
    {
       
        var cliente = GetByPk(id);
        context.Cliente.Remove(cliente);
        context.SaveChanges();
        return cliente;
    }

    public PagedList<Cliente> GetList(int[]? ids = null, string? Nome = null, string? DataNascimento = null,
        string? CPF = null, int page = 0, int pageSize = 0)
    {
        var query =
            from Cliente in context.Cliente
            where
                (ids == null || ids.Length == 0 || ids.Contains(Cliente.Id))
                && (Nome == null || Nome == Cliente.Nome)
            select Cliente;

        return PagedList<Cliente>.Create(query, page, pageSize);
    }




}