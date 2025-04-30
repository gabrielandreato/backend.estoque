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
        telefoneAtualizado.telefone = telefone.telefone;
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
    
    public PagedList<Telefone> GetList(int[]? ids = null, string? Telefones = null,
        int? IdCliente = null, int page = 0, int pageSize = 0)
    {
        var query =
            from Telefone in context.Telefone
            where
                (ids == null || ids.Length == 0 || ids.Contains(Telefone.Id))
                && (Telefone == null || Telefones == Telefone.telefone)
                &&(IdCliente == null || IdCliente == IdCliente.Value)
            select Telefone;

        return PagedList<Telefone>.Create(query, page, pageSize);
    }
    
    
}