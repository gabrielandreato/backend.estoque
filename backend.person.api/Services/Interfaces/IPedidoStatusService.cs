using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Services.Interfaces;

public interface IPedidoStatusService
{
    PedidoStatus Create(CreatePedidoStatusDto pedidoStatus);
    PedidoStatus GetByPk(int id);
    PedidoStatus Update(int id, UpdatePedidoStatusDto pedidoStatus);
    PedidoStatus Remove(int id);
    PagedList<PedidoStatus> GetList(string? ids,  string observacao, int page, int pageSize);
}