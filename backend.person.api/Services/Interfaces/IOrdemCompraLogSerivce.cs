using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IOrdemCompraLogSerivce
{
    OrdemCompraLog Create(CreateOrdemCompraLogDto ordemCompraLog);


    OrdemCompraLog GetByPk(int id);
    
    OrdemCompraLog Update(int id, UpdateOrdemCompraLogDto ordemCompraLogDto);
    OrdemCompraLog Remove(int id);
    PagedList<OrdemCompraLog> GetList (string? ids, int idOrdemCompra,int idOrdemDeCompraStatus, int page, int pageSize);
}