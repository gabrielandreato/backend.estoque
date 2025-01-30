using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IPedidoRepository
{
    Pedido Create(Pedido pedido);
    
    Pedido GetByPk(int id);
    
    Pedido Update(int id, UpdatePedidoDto pedidoDto);
    Pedido Remove(int id);
    PagedList<Pedido> GetList(int[] splittedIds, string observacao, int? idPedidoStatus, int page, int pageSize);
}