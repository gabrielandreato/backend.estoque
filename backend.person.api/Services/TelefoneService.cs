using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class TelefoneService (IPersonDataContext context ):ITelefoneService
{

    public Telefone Create(Telefone telefone)
    {
        context.Telefone.Add(telefone);
        context.SaveChanges();
        return telefone;
    }


    public Telefone GetByPk(int id)
    {
        try
        {
            return context.Telefone.First(x => x.Id == id);
        }
        catch(Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o id",e);
        }
    }

    public Telefone Update(int id, Telefone telefone)
    {
        var telefoneAtualizado = GetByPk(id);
        telefoneAtualizado.Numero = telefone.Numero;
        telefoneAtualizado.IdCliente = telefone.IdCliente;
        return telefoneAtualizado;
    }

    public Telefone Remove(int id)
    {
        Telefone telefoneAtualizado = GetByPk(id);
        context.Telefone.Remove(telefoneAtualizado);
        context.SaveChanges();
        return telefoneAtualizado;
    }
    
    public PagedList<Telefone> GetList(string? ids = null, string? numero = null,
        int? idCliente = null, int page = 0, int pageSize = 0)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        
        var query =
          from telefone in context.Telefone
            where
                (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(telefone.Id))
              &&(numero == null || numero == telefone.Numero)
                &&(idCliente == null|| idCliente == telefone.IdCliente)
            select telefone;

        return PagedList<Telefone>.Create(query, page, pageSize);
    }
    
    
}