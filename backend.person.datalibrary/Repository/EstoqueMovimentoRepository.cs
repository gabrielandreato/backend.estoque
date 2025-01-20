using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class EstoqueMovimentoRepository : IEstoqueMovimentoRepository
{
    private readonly IPersonDataContext _context;
   
    public EstoqueMovimentoRepository (IPersonDataContext context)
    {
        _context = context;
        
    }
    
    public PagedList<EstoqueMovimento> GetList(int[]? ids ,int? IdProduto,int? IdEstoqueMovimento, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from estoquemovimento in _context.EstoqueMovimento
            where
                (ids == null || ids.Length == 0 || ids.Contains(estoquemovimento.Id))
                 &&(IdProduto == null || IdProduto == estoquemovimento.IdProduto)
                &&(IdEstoqueMovimento == null || IdEstoqueMovimento == estoquemovimento.Id)
            select estoquemovimento;

        return PagedList<EstoqueMovimento>.Create(query, page, pageSize);
    }





}