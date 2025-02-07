using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Enum;
using backend.person.modellibrary.Utils;
using backend.person.modellibrary.ViewModel;

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

    public PagedList<EstoqueMovimento> GetList(string? ids, int IdProduto, int IdEstoqueEvento,
        int page, int pageSize)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _estoqueMovimentoRepository.GetList(splittedIds, IdProduto, IdEstoqueEvento, page, pageSize);
    }

    
    public EstoqueMovimento Entrada (CreateEstoqueMovimentoDto estoqueMovimentoDto)
    {
      var entrada = _mapper.Map<EstoqueMovimento>(estoqueMovimentoDto);

      entrada.IdEstoqueEvento = (int)EEstoqueEvento.Entrada;
      entrada.DtInserido = DateTime.Now;
      return _estoqueMovimentoRepository.Create(entrada);
    }

    
    public EstoqueMovimento Saida (CreateEstoqueMovimentoDto estoqueMovimentoDto)
    {
        var saida = _mapper.Map<EstoqueMovimento>(estoqueMovimentoDto);
        saida.IdEstoqueEvento = (int)EEstoqueEvento.Saida;
        saida.DtInserido = DateTime.Now;
        return _estoqueMovimentoRepository.Create(saida);
    }

   
    
    
}





