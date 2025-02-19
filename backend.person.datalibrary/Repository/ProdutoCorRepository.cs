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
    

    public ProdutoCorRepository(IPersonDataContext context)
    {
        _context = context;
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

    public ProdutoCor Update (int id, ProdutoCor produtoCor)
    {
        var produtocorDoBanco = GetByPk(id);
        produtocorDoBanco.IdProduto = produtoCor.IdProduto;
        produtocorDoBanco.IdCor = produtoCor.IdCor;
        _context.SaveChanges();
        return produtocorDoBanco;
    }

    public ProdutoCor Remove (int id)
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