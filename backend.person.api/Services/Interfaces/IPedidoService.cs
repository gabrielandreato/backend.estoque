using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IPedidoService
{
    Pedido Create(Pedido pedido);
    Pedido GetByPk(int id);
    Pedido Update(int id ,Pedido pedido);
    Pedido Remove(int id);
    PagedList<Pedido> GetList(string? ids, string observacao, int idPedidoStatus, int page, int pageSize);

    Pedido PedidoComItens (CreatePedidoComItensDto pedidoComItensDto);
    
    Pedido Faturar (int id);
    
    Pedido Cancelado(int id);
}