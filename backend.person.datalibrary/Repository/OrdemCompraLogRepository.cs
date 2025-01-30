using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class OrdemCompraLogRepository : IOrdemCompraLogRepository
{
    private readonly IPersonDataContext _context;
    private readonly IMapper _mapper;


    public OrdemCompraLogRepository(IPersonDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public OrdemCompraLog Create(OrdemCompraLog ordemCompraLog)
    {
        _context.OrdemCompraLog.Add(ordemCompraLog);
        _context.SaveChanges();
        return ordemCompraLog;
    }

    public OrdemCompraLog GetByPk(int id)
    {
        try
        {
            return _context.OrdemCompraLog.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public OrdemCompraLog Update (int id, UpdateOrdemCompraLogDto ordemCompraLogDto)
    {
        var ordemCompraLog = GetByPk(id);
        _mapper.Map(ordemCompraLogDto, ordemCompraLog);
        _context.SaveChanges();
        return ordemCompraLog;
    }

    public OrdemCompraLog Remove(int id)
    {
        var ordemCompraLog = GetByPk(id);
        _context.OrdemCompraLog.Remove(ordemCompraLog);
        _context.SaveChanges();
        return ordemCompraLog;
    }
    
    public PagedList<OrdemCompraLog> GetList(int[]? ids,int? idOrdemCompra, int? idOrdemCompraStatus, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from ordemCompraLog in _context.OrdemCompraLog
            where
                (ids == null || ids.Length == 0 || ids.Contains(ordemCompraLog.Id))
                &&(idOrdemCompra == null || idOrdemCompra == idOrdemCompra)
                &&(idOrdemCompraStatus ==null || idOrdemCompraStatus == ordemCompraLog.IdOrdemCompraStatus)
                
            select ordemCompraLog;

        return PagedList<OrdemCompraLog>.Create(query, page, pageSize);
    }
    
    
    
    
}