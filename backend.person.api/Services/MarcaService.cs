using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class MarcaService(IPersonDataContext context) : IMarcaService
{
    public Marca Create (Marca marca)
    {
        context.Marca.Add(marca);
        context.SaveChanges();
        return marca;
         
    }

    public Marca GetByPk(int id)
    {
        try
        {
            return context.Marca.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public Marca Remove(int id)
    {
        var marca = GetByPk(id);
        context.Marca.Remove(marca);
        context.SaveChanges();
        return marca;
    }
    public Marca Update (int id, Marca marca)
    {
        var marcaAtualizada = GetByPk(id);
        marcaAtualizada.Descricao = marca.Descricao;
        context.SaveChanges();
        return marcaAtualizada;
    }
    
    public PagedList<Marca> GetList(int[]? ids = null, string? descricao = null, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from marca in context.Marca
            where
                (ids == null || ids.Length == 0 || ids.Contains(marca.Id))
                && (descricao == null || descricao == marca.Descricao)
            select marca;

        return PagedList<Marca>.Create(query, page, pageSize);
    }
    
    
}