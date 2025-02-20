using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IPedidoLogService
{
    PedidoLog Create(PedidoLog pedidoLog);
    PedidoLog GetByPk(int id);
    PedidoLog Update(int id, PedidoLog pedidoLog);
    PedidoLog Remove(int id);
    PagedList<PedidoLog> GetList(int[]? ids, int? idPedido, int? idStatus, int page = 0, int pageSize =0 );
}