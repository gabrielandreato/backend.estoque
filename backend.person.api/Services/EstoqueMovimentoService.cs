using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Repository;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class EstoqueMovimentoService : IEstoqueMovimentoService
{
    private readonly IEstoqueMovimentoRepository _estoqueMovimentoRepository;
    private readonly IMapper _mapper;

    public EstoqueMovimentoService(IEstoqueMovimentoRepository estoqueMovimentoRepository, IMapper mapper)
    {
       _estoqueMovimentoRepository = estoqueMovimentoRepository;
       _mapper = mapper;
    }

    public PagedList<EstoqueMovimento> GetList(string? ids, int IdProduto,int IdEstoqueMovimento,
        int page, int pageSize)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _estoqueMovimentoRepository.GetList(splittedIds,IdProduto,IdEstoqueMovimento , page, pageSize);
    }
    
    
    
}




