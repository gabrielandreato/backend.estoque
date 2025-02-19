using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IOrdemCompraStatusRepository
{
   OrdemCompraStatus Create (OrdemCompraStatus ordemcompraStatus);
   
   OrdemCompraStatus Update(int id, OrdemCompraStatus ordemCompraStatus);
   OrdemCompraStatus Remove(int id);

   OrdemCompraStatus GetByPk(int id);
   PagedList<OrdemCompraStatus> GetList(int[] splittedIds, string? descricao, int page, int pageSize);
}