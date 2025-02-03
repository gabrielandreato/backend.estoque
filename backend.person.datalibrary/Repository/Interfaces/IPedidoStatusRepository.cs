using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IPedidoStatusRepository
{
    PedidoStatus Create(PedidoStatus pedidoStatus);
    
    PedidoStatus GetByPk(int id);
    PedidoStatus Update(int id, PedidoStatus pedidoStatus);
    PedidoStatus Remove(int id);

    PagedList<PedidoStatus> GetList(int[] splittedIds, string descricao, int page, int pageSize);
}