using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using backend.person.modellibrary.ViewModel;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IEstoqueMovimentoRepository
{
    PagedList<EstoqueMovimento> GetList (int[]? ids, int? idProduto, int? idEstoqueEvento,
        int page = 0, int pageSize = 0);
    
     EstoqueMovimento Create (EstoqueMovimento estoqueMovimento);


  
}