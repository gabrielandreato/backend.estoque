using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class ProdutoCategoriaService(IPersonDataContext _context) : IProdutoCategoriaService
{
    public ProdutoCategoria Create(ProdutoCategoria produtoCategoria)
    {
        _context.ProdutoCategoria.Add(produtoCategoria);
        _context.SaveChanges();
        return produtoCategoria;
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

    public ProdutoCategoria Update(int id, ProdutoCategoria produtoCategoria)
    {
        var produtoCategoriaAtualizado = GetByPk(id);
        produtoCategoriaAtualizado.DescCategoria = produtoCategoria.DescCategoria;
        _context.SaveChanges();
        return produtoCategoriaAtualizado;
    }

    public PagedList<ProdutoCategoria> GetList(string? ids = null, string? descCategoria = null,
        int page = 0, int pageSize = 0)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);

        var query =
            from produto in _context.ProdutoCategoria
            where
                (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(produto.Id))
                && (descCategoria == null || descCategoria == produto.DescCategoria)
            select produto;

        return PagedList<ProdutoCategoria>.Create(query, page, pageSize);
    }
}