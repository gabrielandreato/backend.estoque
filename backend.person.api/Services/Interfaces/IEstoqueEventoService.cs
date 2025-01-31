using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IEstoqueEventoService
{
    EstoqueEvento Create(CreateEstoqueEventoDto estoqueEventoDto);
    EstoqueEvento GetByPk(int id);

    EstoqueEvento Update(int id, EstoqueEvento estoqueEvento);

    EstoqueEvento Delete(int id);
    PagedList<EstoqueEvento> GetList(string? ids, string descricao, int page, int pageSize);
}