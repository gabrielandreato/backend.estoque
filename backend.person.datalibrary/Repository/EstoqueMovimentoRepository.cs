using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class EstoqueMovimentoRepository : IEstoqueMovimentoRepository
{
    private readonly IPersonDataContext _context;
    private readonly IMapper _mapper;
   
    public EstoqueMovimentoRepository (IPersonDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = _mapper;

    }
    
    public PagedList<EstoqueMovimento> GetList(int[]? ids ,int? IdProduto,int? IdEstoqueEvento, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from estoqueMovimento in _context.EstoqueMovimento
            where
                (ids == null || ids.Length == 0 || ids.Contains(estoqueMovimento.Id))
                 &&(IdProduto == null || IdProduto == estoqueMovimento.IdProduto)
                &&(IdEstoqueEvento == null || IdEstoqueEvento == estoqueMovimento.Id)
            select estoqueMovimento;

        return PagedList<EstoqueMovimento>.Create(query, page, pageSize);
    }

    public EstoqueMovimento Create (EstoqueMovimento estoqueMovimento)
    {
        _context.EstoqueMovimento.Add(estoqueMovimento);
        _context.SaveChanges();
        return estoqueMovimento;
    }

   
    

}