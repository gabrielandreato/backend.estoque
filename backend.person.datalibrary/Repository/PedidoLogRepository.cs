using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class PedidoLogRepository : IPedidoLogRepository
{
    private readonly IPersonDataContext _context;

    public PedidoLogRepository(IPersonDataContext context)
    {
        _context = context;
    }

    public PedidoLog Create(PedidoLog pedidoLog)
    {
        _context.PedidoLog.Add(pedidoLog);
        _context.SaveChanges();
        return pedidoLog;
    }

    public PedidoLog GetByPk(int id)
    {
        try
        {
            var pedidolog = _context.PedidoLog.First(x => x.Id == id);
            return pedidolog;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public PedidoLog Update(int id, PedidoLog pedidoLog)
    {
        var pedidolog = GetByPk(id);
        pedidolog.IdPedido = pedidoLog.IdPedido;
        pedidolog.IdStatus = pedidoLog.IdStatus;
        _context.SaveChanges();
        return pedidolog;
    }

    public PedidoLog Remove(int id)
    {
        var pedidoLog = GetByPk(id);
        _context.PedidoLog.Remove(pedidoLog);
        _context.SaveChanges();
        return pedidoLog;
    }
   
    public PagedList<PedidoLog> GetList(int[]? ids, int? idPedido, int? idStatus, int page = 0, int pageSize =0 )
    {
        var query =
            from pedidoLog in _context.PedidoLog
            where
                (ids == null || ids.Length == 0 || ids.Contains(pedidoLog.Id))
                && (idPedido == null || idPedido == pedidoLog.IdPedido)
                &&(idStatus == null || idStatus == pedidoLog.IdStatus)
            select pedidoLog;

        return PagedList<PedidoLog>.Create(query, page, pageSize);
    }
}