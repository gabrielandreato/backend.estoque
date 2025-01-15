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
    private readonly IMapper _mapper;
    
    public ProdutoCategoriaService(IProdutoCategoriaRepository produtoCategoriaRepository, IMapper mapper)
    {
        _produtoCategoriaRepository = produtoCategoriaRepository;
        _mapper = mapper;
    }
    
    public ProdutoCategoria Create (CreateProdutoCategoriaDto produtoCategoriaDto)
    {
        var produtocategoria = _mapper.Map<ProdutoCategoria>(produtoCategoriaDto);
        return _produtoCategoriaRepository.Create(produtocategoria);
     
    }

    public ProdutoCategoria GetByPk(int id)
    {
        return _produtoCategoriaRepository.GetByPk(id);
    }

    public ProdutoCategoria Remove(int id)
    {
        return _produtoCategoriaRepository.Remove(id);
    }

    public ProdutoCategoria Update (int id,UpdateProdutoCategoriaDto updateprodutoCategoriaDto)
    {
        return _produtoCategoriaRepository.Update(id, updateprodutoCategoriaDto );
    }

    public PagedList<ProdutoCategoria> GetList(string? ids, string? descricao,
        int page, int pageSize )
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _produtoCategoriaRepository.GetList(splittedIds, descricao, page, pageSize);
    }
    
       
    
    
    
}