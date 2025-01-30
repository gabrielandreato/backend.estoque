using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IPedidoItensRepository
{
    PedidoItens Create(PedidoItens pedidoitens);
    
    PedidoItens GetByPk(int id);
    PedidoItens Update(int id, UpdatePedidoItensDto pedidoItensDto);

    PagedList<PedidoItens> GetList (int[] splittedIds, int? idPedido, int? idProduto, int? quantidade, int page, int pageSize);
}