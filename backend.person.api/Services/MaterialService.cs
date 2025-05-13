using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using SQLitePCL;

namespace backend.person.api.Services;

public class MaterialService(IPersonDataContext context):IMaterialService
{
    public Material  Create (Material material)
    {
        context.Material.Add(material);
        context.SaveChanges();
        return material;
    }

    public Material GetByPk(int id)
    {
        try
        {
            return context.Material.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public Material Update(int id, Material material)
    {
        var materialAtualizado = GetByPk(id);
        materialAtualizado.Descricao= material.Descricao;
        context.SaveChanges();
        return materialAtualizado;

    }

    public Material Remove(int id)
    {
        var material = GetByPk(id);
        context.Material.Remove(material);
        context.SaveChanges();
        return material;
    }
    
    
    public PagedList<Material> GetList (string? ids  = null ,string? descricao = null , int page = 0, int pageSize = 0)
    {
       
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        
        var query =
            from material in context.Material
            where
                (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(material.Id))
                && (descricao == null || descricao == material.Descricao)
            select material;

        return PagedList<Material>.Create(query, page, pageSize);
    }
    
    
    
    
}