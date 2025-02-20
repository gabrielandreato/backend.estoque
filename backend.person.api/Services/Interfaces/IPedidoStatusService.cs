using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Services.Interfaces;

public interface IPedidoStatusService
{
    PedidoStatus Create(PedidoStatus pedidoStatus);
    PedidoStatus GetByPk(int id);
    PedidoStatus Update(int id, PedidoStatus pedidoStatus);
    PedidoStatus Remove(int id);
    PagedList<PedidoStatus> GetList(int[]? ids,  string observacao, int page, int pageSize);
}