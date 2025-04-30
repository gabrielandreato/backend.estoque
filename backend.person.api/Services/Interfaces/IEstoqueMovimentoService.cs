using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using backend.person.modellibrary.ViewModel;

namespace backend.person.api.Services.Interfaces;

public interface IEstoqueMovimentoService
{
    PagedList<EstoqueMovimento> GetList(string? ids ,int? idProduto,int? idEstoqueEvento, 
        int page = 0, int pageSize = 0);

    EstoqueMovimento Entrada(EstoqueMovimento estoqueMovimento);

    EstoqueMovimento Saida(EstoqueMovimento estoqueMovimento);
   
}