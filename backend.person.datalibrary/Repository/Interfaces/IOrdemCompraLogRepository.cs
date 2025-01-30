using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IOrdemCompraLogRepository
{
    OrdemCompraLog Create(OrdemCompraLog ordemCompraLog);
    
    OrdemCompraLog GetByPk(int id);
    OrdemCompraLog Update(int id, UpdateOrdemCompraLogDto ordemCompraLogDto);
    OrdemCompraLog Remove(int id);
    PagedList<OrdemCompraLog> GetList(int[]? splittedIds,int? idOrdemCompra,int? idOrdemCompraStatus, int page, int pageSize);
}