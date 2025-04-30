using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IOrdemCompraLogSerivce
{
    OrdemCompraLog Create(OrdemCompraLog ordemCompraLog);
    OrdemCompraLog GetByPk(int id);
    OrdemCompraLog Update(int id, OrdemCompraLog ordemCompraLog);
    OrdemCompraLog Remove(int id);
    PagedList<OrdemCompraLog> GetList (string? ids,int? idOrdemCompra, int? idOrdemCompraStatus, 
        int page = 0, int pageSize = 0);
}