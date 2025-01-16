using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using Microsoft.EntityFrameworkCore;

namespace backend.person.datalibrary.Repository;

public class ProdutoCategoriaRepository : IProdutoCategoriaRepository
{
    private readonly IPersonDataContext _context;

    private readonly IMapper _mapper;
    
    public ProdutoCategoriaRepository(IPersonDataContext context , IMapper mapper)
    {
        _context = context; 
        _mapper = mapper;
    }
    
    
    public ProdutoCategoria Create(ProdutoCategoria produtocategoria)
    {
        _context.ProdutoCategoria.Add(produtocategoria);
        _context.SaveChanges();
        return produtocategoria;
    }
    
    public ProdutoCategoria GetByPk(int id)
    {
        try
        {
            return _context.ProdutoCategoria.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public ProdutoCategoria Remove(int id)
    {
        var produtocategoria = GetByPk(id);
        _context.ProdutoCategoria.Remove(produtocategoria);
        _context.SaveChanges();
        return produtocategoria;
    }

    public ProdutoCategoria Update(int id, UpdateProdutoCategoriaDto updateprodutocategoria)
    {
        var produtocategoria = GetByPk(id);
        _mapper.Map(updateprodutocategoria, produtocategoria);
        _context.SaveChanges();
        return produtocategoria;
    }
    
    public PagedList<ProdutoCategoria> GetList(int[]? ids = null, string? descricao = null, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from produto in _context.ProdutoCategoria
            where
                (ids == null || ids.Length == 0 || ids.Contains(produto.Id))
                && (descricao == null || descricao == produto.Descricao )
                
                
            select produto;

        return PagedList<ProdutoCategoria>.Create(query, page, pageSize);
    }
    
    
    
}