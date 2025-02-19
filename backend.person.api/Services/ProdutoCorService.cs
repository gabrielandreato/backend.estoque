using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class ProdutoCorService : IProdutoCorService
{
    private readonly IProdutoCorRepository _produtoCorRepository;
    

    public ProdutoCorService(IProdutoCorRepository produtoCorRepository)
    {
        _produtoCorRepository = produtoCorRepository;
        
    }

    public ProdutoCor Create(ProdutoCor produtoCor)
    {
        
        return _produtoCorRepository.Create(produtoCor);
    }

    public ProdutoCor GetByPk(int id)
    {
        return _produtoCorRepository.GetByPk(id);
    }

    public ProdutoCor Update(int id, ProdutoCor produtoCor)
    {
        return _produtoCorRepository.Update(id, produtoCor);
    }

    public ProdutoCor Delete(int id)
    {
        return _produtoCorRepository.Remove(id);
    }
    
    public PagedList<ProdutoCor> GetList (string? ids,int? idProduto, int? idCor, 
        int page, int pageSize)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _produtoCorRepository.GetList(splittedIds, idProduto, idCor,page, pageSize);
    }
    
    
}