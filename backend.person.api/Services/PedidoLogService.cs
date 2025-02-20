using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class PedidoLogService(IPersonDataContext context) : IPedidoLogService
{
   

    
    public PedidoLog Create(PedidoLog pedidoLog)
    {
        context.PedidoLog.Add(pedidoLog);
        context.SaveChanges();
        return pedidoLog;
    }

    public PedidoLog GetByPk(int id)
    {
        try
        {
            var pedidolog = context.PedidoLog.First(x => x.Id == id);
            return pedidolog;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public PedidoLog Update(int id, PedidoLog pedidoLog)
    {
        var pedidologDoBanco = GetByPk(id);
        pedidologDoBanco.IdPedido = pedidoLog.IdPedido;
        pedidologDoBanco.IdStatus = pedidoLog.IdStatus;
        context.SaveChanges();
        return pedidologDoBanco;
    }


    public PedidoLog Remove(int id)
    {
        var pedidoLog = GetByPk(id);
        context.PedidoLog.Remove(pedidoLog);
        context.SaveChanges();
        return pedidoLog;
    }

    public PagedList<PedidoLog> GetList (int[]? ids, int? idPedido, int? idStatus, int page = 0, int pageSize =0 )
    {
        var query =
            from pedidoLog in context.PedidoLog
            where
                (ids == null || ids.Length == 0 || ids.Contains(pedidoLog.Id))
                && (idPedido == null || idPedido == pedidoLog.IdPedido)
                &&(idStatus == null || idStatus == pedidoLog.IdStatus)
            select pedidoLog;

        return PagedList<PedidoLog>.Create(query, page, pageSize);
    }
    
}