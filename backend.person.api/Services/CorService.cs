using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using SQLitePCL;

namespace backend.person.api.Services;

public class CorService(IPersonDataContext context) : ICorService
{
  
    public Cor Create(Cor cor)
    { 
        context.Cor.Add(cor);
        context.SaveChanges();
        return cor;
        
    }

    public Cor GetByPk(int id)
    {
        try
        {
            return context.Cor.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new  ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }


    public Cor Remove(int id)
    {
        var cor = GetByPk(id);
        context.Cor.Remove(cor);
        context.SaveChanges();
        return cor;
    }

    public Cor Update(int id, Cor cor)
    {
        var corAtualizada = GetByPk(id);
        corAtualizada.Descricao = cor.Descricao;
        context.SaveChanges();
        return corAtualizada;
    }
 
    public PagedList<Cor> GetList(int[]? ids = null, string? descricao = null, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from cor in context.Cor
            where 
                (ids == null || ids.Length == 0 || ids.Contains(cor.Id))
                && (descricao == null || descricao == cor.Descricao)
            select cor;

        return PagedList<Cor>.Create(query, page, pageSize);
    }
   
}