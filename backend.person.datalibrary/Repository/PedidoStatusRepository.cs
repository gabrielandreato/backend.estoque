using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class PedidoStatusRepository : IPedidoStatusRepository
{
    private readonly IPersonDataContext _context;

    public PedidoStatusRepository(IPersonDataContext context)
    {
        _context = context;
    }

    public PedidoStatus Create(PedidoStatus pedidoStatus)
    {
        _context.PedidoStatus.Add(pedidoStatus);
        _context.SaveChanges();
        return pedidoStatus;
    }

    public PedidoStatus GetByPk(int id)
    {
        try
        {
            var pedidostatus = _context.PedidoStatus.First(x => x.Id == id);
            return pedidostatus;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public PedidoStatus Update(int id, PedidoStatus pedidoStatus)
    {
        var pedidoByPk = GetByPk(id);
        
        pedidoByPk.Descricao = pedidoStatus.Descricao;
        
        _context.SaveChanges();
        return pedidoStatus;
    }

    public PedidoStatus Remove(int id)
    {
        var pedidoStatus = GetByPk(id);
        _context.PedidoStatus.Remove(pedidoStatus);
        _context.SaveChanges();
        return pedidoStatus;
    }

    public PagedList<PedidoStatus> GetList(int[]? ids, string? descricao,
        int page = 0, int pageSize = 0)
    {
        var query =
            from pedidostatus in _context.PedidoStatus
            where
                (ids == null || ids.Length == 0 || ids.Contains(pedidostatus.Id))
                && (descricao == null || descricao == pedidostatus.Descricao)
            select pedidostatus;

        return PagedList<PedidoStatus>.Create(query, page, pageSize);
    }
}