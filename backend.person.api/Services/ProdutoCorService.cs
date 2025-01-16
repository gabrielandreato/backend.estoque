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
    private readonly IMapper _mapper;

    public ProdutoCorService(IProdutoCorRepository produtoCorRepository, IMapper mapper)
    {
        _produtoCorRepository = produtoCorRepository;
        _mapper = mapper;
    }

    public ProdutoCor Create(CreateProdutoCorDto produtoCor)
    {
        var produtocor = _mapper.Map<ProdutoCor>(produtoCor);
        return _produtoCorRepository.Create(produtocor);
    }

    public ProdutoCor GetByPk(int id)
    {
        return _produtoCorRepository.GetByPk(id);
    }

    public ProdutoCor Update(int id, UpdateProdutoCorDto updateprodutoCorDto)
    {
        return _produtoCorRepository.Update(id, updateprodutoCorDto);
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