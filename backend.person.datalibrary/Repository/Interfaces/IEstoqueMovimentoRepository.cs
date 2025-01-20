using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IEstoqueMovimentoRepository
{
    PagedList<EstoqueMovimento> GetList (int[]? ids, int? IdProduto, int? IdEstoqueMovimento,
        int page = 0, int pageSize = 0);
}