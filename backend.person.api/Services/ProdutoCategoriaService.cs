using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class ProdutoCategoriaService : IProdutoCategoriaService
{
    private readonly IProdutoCategoriaRepository _produtoCategoriaRepository;
    
    
    public ProdutoCategoriaService(IProdutoCategoriaRepository produtoCategoriaRepository)
    {
        _produtoCategoriaRepository = produtoCategoriaRepository;
        
    }
    
    public ProdutoCategoria Create (ProdutoCategoria produtoCategoria)
    {
       return _produtoCategoriaRepository.Create(produtoCategoria);
    }

    public ProdutoCategoria GetByPk(int id)
    {
        return _produtoCategoriaRepository.GetByPk(id);
    }

    public ProdutoCategoria Remove(int id)
    {
        return _produtoCategoriaRepository.Remove(id);
    }

    public ProdutoCategoria Update (int id,ProdutoCategoria produtoCategoria)
    {
         return _produtoCategoriaRepository.Update(id, produtoCategoria);
        
    }

    public PagedList<ProdutoCategoria> GetList(string? ids, string? descricao,
        int page, int pageSize )
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _produtoCategoriaRepository.GetList(splittedIds, descricao, page, pageSize);
    }
    
       
    
    
    
}