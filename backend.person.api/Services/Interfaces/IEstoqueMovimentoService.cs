using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IEstoqueMovimentoService
{
    PagedList<EstoqueMovimento> GetList(string? ids, int IdProduto, int IdEstoqueEvento, int page, int pageSize);

    EstoqueMovimento Entrada(CreateEstoqueMovimentoDto estoqueMovimentoDto);

    EstoqueMovimento Saida(CreateEstoqueMovimentoDto estoqueMovimentoDto);
}