using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IOrdemCompraStatusService
{
    OrdemCompraStatus Create(OrdemCompraStatus ordemCompraStatus);
    OrdemCompraStatus Update(int id, OrdemCompraStatus ordemCompraStatus);
    OrdemCompraStatus Remove(int id);
    OrdemCompraStatus GetByPk(int id);
    PagedList<OrdemCompraStatus> GetList (string? ids, string? descricao,
        int page, int pageSize);
}