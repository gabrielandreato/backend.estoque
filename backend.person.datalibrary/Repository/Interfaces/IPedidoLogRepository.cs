using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IPedidoLogRepository
{
    public PedidoLog Create (PedidoLog pedidoLog);

    PedidoLog GetByPk(int id);
    PedidoLog Update(int id, PedidoLog pedidoLog);
    PedidoLog Remove(int id);
    PagedList<PedidoLog> GetList(int[] splittedIds, int? idPedido, int? idStatus, int page = 0, int pageSize = 0);
}