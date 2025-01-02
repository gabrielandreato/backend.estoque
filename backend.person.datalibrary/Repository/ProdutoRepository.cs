using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using Microsoft.EntityFrameworkCore;

namespace backend.person.datalibrary.Repository;

public class ProdutoRepository : IProdutoRepository
{
    private readonly IPersonDataContext _context;

    private readonly IMapper _mapper;

    public ProdutoRepository(IPersonDataContext context , IMapper mapper)
    {
        _context = context; 
        _mapper = mapper;
    }

    public Produto Create(Produto produto)
    {
        _context.Produto.Add(produto);

        _context.SaveChanges();
        return produto;
    }

    public Produto GetByPk(int id)
    {
        try
        {
            return _context.Produto.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }
    public Produto Remove(int id)
    {
        var produto = GetByPk(id);
        _context.Produto.Remove(produto);
        _context.SaveChanges();
        return produto;
    }

    public Produto Update(int id, UpdateProdutoDto updateProdutoDto)
    {
        var produto = GetByPk(id);
        _mapper.Map(updateProdutoDto, produto);
        _context.SaveChanges();
        return produto;
    }

    public PagedList<Produto> GetList(int[]? ids = null, string? descricao = null, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from produto in _context.Produto
            where
                (ids == null || ids.Length == 0 || ids.Contains(produto.Id))
                && (descricao == null || descricao == produto.Descricao)
            select produto;

        return PagedList<Produto>.Create(query, page, pageSize);
    }



}
