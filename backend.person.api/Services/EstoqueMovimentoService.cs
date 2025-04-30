using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Enum;
using backend.person.modellibrary.Utils;
using backend.person.modellibrary.ViewModel;

namespace backend.person.api.Services;

public class EstoqueMovimentoService( IPersonDataContext context) : IEstoqueMovimentoService
{
   
    public PagedList<EstoqueMovimento> GetList (string? ids ,int? idProduto,int? idEstoqueEvento, 
        int page = 0, int pageSize = 0)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        
        var query =
            from estoqueMovimento in context.EstoqueMovimento
            where
                (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(estoqueMovimento.Id))
                &&(idProduto == null || idProduto == estoqueMovimento.IdProduto)
                &&(idEstoqueEvento == null || idEstoqueEvento == estoqueMovimento.Id)
            select estoqueMovimento;

        return PagedList<EstoqueMovimento>.Create(query, page, pageSize);
    }

    public EstoqueMovimento Entrada (EstoqueMovimento estoqueMovimento)
    {
        estoqueMovimento.IdEstoqueEvento = (int) EEstoqueEvento.Entrada;
        estoqueMovimento.DtInserido =DateTime.Now;
        return Create(estoqueMovimento);
    }

    
    public EstoqueMovimento Saida (EstoqueMovimento estoqueMovimento)
    {
       
       return Create(estoqueMovimento);
        
    }

    public EstoqueMovimento Create (EstoqueMovimento estoqueMovimento)
    {
        context.EstoqueMovimento.Add(estoqueMovimento);
        context.SaveChanges();
        return estoqueMovimento;
    }
    
}





