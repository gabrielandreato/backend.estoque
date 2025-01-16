using System.Linq.Expressions;
using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class ProdutoCorRepository : IProdutoCorRepository
{
    private readonly IPersonDataContext _context;

    private readonly IMapper _mapper;

    public ProdutoCorRepository(IPersonDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ProdutoCor Create(ProdutoCor produtoCor)
    {
         _context.ProdutoCor.Add(produtoCor);
         _context.SaveChanges();
         return produtoCor;
    }

    public ProdutoCor GetByPk(int id)
    {
        try
        {
            return _context.ProdutoCor.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException ("Não foi possivel encontrar o Id",e);
        }
    }

    public ProdutoCor Update(int id, UpdateProdutoCorDto updateprodutoCorDto)
    {
        var produtocor = GetByPk(id);
        _mapper.Map(updateprodutoCorDto, produtocor);
        _context.SaveChanges();
        return produtocor;
    }

    public ProdutoCor Delete(int id)
    {
        var produtocor = GetByPk(id);
        _context.ProdutoCor.Remove(produtocor);
        _context.SaveChanges();
        return produtocor;
        
    }
     
    public PagedList<ProdutoCor> GetList(int[]? ids = null, int? IdProduto = null, int? IdCor = null,
        int page = 0, int pageSize = 0)
    {
        var query = 
            from produtocor in _context.ProdutoCor
            where
                 (ids == null || ids.Length == 0 || ids.Contains(produtocor.Id))
                &&(IdProduto == null || IdProduto == produtocor.IdProduto)
                 &&(IdCor == null || IdCor == produtocor.IdCor)
                select produtocor;

                return PagedList<ProdutoCor>.Create(query, page, pageSize);
    }  
           
        
      
        
    
    
    
    
    
}