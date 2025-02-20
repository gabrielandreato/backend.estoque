using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IPedidoItensService
{
    PedidoItens Create(PedidoItens pedidoItens);

    PedidoItens GetByPk (int id);
    
    PedidoItens Update(int id, UpdatePedidoItensDto pedidoItensDto);
    
    PagedList<PedidoItens> GetList (int[]? ids, int? idPedido,int? idProduto, int? quantidade, 
        int page = 0, int pageSize = 0);
}