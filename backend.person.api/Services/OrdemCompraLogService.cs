using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class OrdemCompraLogService(IPersonDataContext context): IOrdemCompraLogSerivce
{
    public OrdemCompraLog Create(OrdemCompraLog ordemCompraLog)
    {
        ordemCompraLog.DtLog = DateTime.Now;
        context.OrdemCompraLog.Add(ordemCompraLog);
        context.SaveChanges();
        return ordemCompraLog;
        
    }

    public OrdemCompraLog GetByPk(int id)
    {
        try
        {
            return context.OrdemCompraLog.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public OrdemCompraLog Update(int id, OrdemCompraLog ordemCompraLog)
    {
        var ordemCompraLogAtualizada = GetByPk(id);
        ordemCompraLogAtualizada.IdOrdemCompraStatus = ordemCompraLog.IdOrdemCompraStatus;
        ordemCompraLogAtualizada.IdOrdemCompra = ordemCompraLog.IdOrdemCompra;
        context.SaveChanges();
        return ordemCompraLogAtualizada;
    }

    public OrdemCompraLog Remove(int id)
    {
        var ordemCompraLog = GetByPk(id);
        context.OrdemCompraLog.Remove(ordemCompraLog);
        context.SaveChanges();
        return ordemCompraLog;
    }
    public PagedList<OrdemCompraLog> GetList (int[]? ids,int? idOrdemCompra, int? idOrdemCompraStatus, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from ordemCompraLog in context.OrdemCompraLog
            where
                (ids == null || ids.Length == 0 || ids.Contains(ordemCompraLog.Id))
                &&(idOrdemCompra == null || idOrdemCompra == idOrdemCompra)
                &&(idOrdemCompraStatus ==null ||
                   idOrdemCompraStatus == ordemCompraLog.IdOrdemCompraStatus)
                
            select ordemCompraLog;

        return PagedList<OrdemCompraLog>.Create(query, page, pageSize);
    }
}