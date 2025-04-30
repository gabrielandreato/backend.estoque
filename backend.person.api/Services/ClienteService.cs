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
            return context.Cliente.First(x => x.id == id);
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

    public PagedList<Cliente> GetList(string? ids = null, string? nome = null, DateTime? dataNascimento = null,
        string? cpf = null, int page = 0, int pageSize = 0)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        
        var query =
            from cliente in context.Cliente
            where
                (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(cliente.id))
                && (nome == null || nome == cliente.Nome)
                &&(dataNascimento == null || dataNascimento == cliente.DataNascimento)
                && (cpf == null || cpf == cliente.CPF)
            select cliente;

        return PagedList<Cliente>.Create(query, page, pageSize);
    }




}