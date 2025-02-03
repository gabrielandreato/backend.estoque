using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class PedidoLogService : IPedidoLogService
{
    private readonly IPedidoLogRepository _pedidoLogRepository;

    public PedidoLogService(IPedidoLogRepository pedidoLogRepository)
    {
        _pedidoLogRepository = pedidoLogRepository;
    }

    
    public PedidoLog Create(PedidoLog pedidoLog)
    {
        pedidoLog.DtLogPedido = DateTime.Now;
        return _pedidoLogRepository.Create(pedidoLog);
    }

    public PedidoLog GetByPk(int id)
    {
        return _pedidoLogRepository.GetByPk(id);
    }

    public PedidoLog Update(int id, PedidoLog pedidoLog)
    {
        return _pedidoLogRepository.Update(id, pedidoLog);
    }


    public PedidoLog Remove(int id)
    {
        return _pedidoLogRepository.Remove(id);
    }

    public PagedList<PedidoLog> GetList(string? ids, int idPedido, int idStatus, int page, int pageSize)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _pedidoLogRepository.GetList(splittedIds,idPedido,idStatus, page, pageSize);
    }
    
}