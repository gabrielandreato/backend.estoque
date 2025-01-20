using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IEstoqueMovimentoService
{
    PagedList<EstoqueMovimento> GetList
        (string? ids,int IdProduto,int IdEstoqueMovimento, int page, int pageSize);
}