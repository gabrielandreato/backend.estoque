using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public interface IEstoqueEventoRepository
{
    EstoqueEvento Create(EstoqueEvento estoqueEvento);
    
    EstoqueEvento GetByPk(int id);
    EstoqueEvento Update(int id, EstoqueEvento estoqueEvento);
    EstoqueEvento Delete(int id);

    PagedList<EstoqueEvento> GetList(int[]? splittedIds, string? descricao, int page = 0, int pageSize =0 );
}