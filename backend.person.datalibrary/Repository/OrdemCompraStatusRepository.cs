using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class OrdemCompraStatusRepository : IOrdemCompraStatusRepository
{
    private readonly IPersonDataContext _context;
    private readonly IMapper _mapper;

    public OrdemCompraStatusRepository(IPersonDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public OrdemCompraStatus Create(OrdemCompraStatus ordemCompraStatus)
    {
        _context.OrdemCompraStatus.Add(ordemCompraStatus);
        _context.SaveChanges();
        return ordemCompraStatus;
    }

    public PagedList<OrdemCompraStatus> GetList(int[]? ids = null, string? descricao = null, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from ordemCompraStatus in _context.OrdemCompraStatus
            where
                (ids == null || ids.Length == 0 || ids.Contains(ordemCompraStatus.Id))
                && (descricao == null || descricao == ordemCompraStatus.Descricao )
                
                
            select ordemCompraStatus;

        return PagedList<OrdemCompraStatus>.Create(query, page, pageSize);
    }

    public OrdemCompraStatus Update(int id, UpdateOrdemCompraStatusDto updateOrdemCompraStatusDto)
    {
        var ordemCompraStatus = GetByPk(id);
        _context.OrdemCompraStatus.Add(ordemCompraStatus);
        _context.SaveChanges();
        return ordemCompraStatus;
    }


    public OrdemCompraStatus Remove(int id)
    {
        var ordemCompraStatus = GetByPk(id);
        _context.OrdemCompraStatus.Remove(ordemCompraStatus);
        _context.SaveChanges();
        return ordemCompraStatus;
    }

    public OrdemCompraStatus GetByPk(int id)
    {
        try
        {
            return _context.OrdemCompraStatus.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }
    
    
}