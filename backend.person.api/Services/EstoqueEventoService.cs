using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Profiles;
using backend.person.datalibrary.Repository;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;

namespace backend.person.api.Services;

public class EstoqueEventoService : IEstoqueEventoService
{
    private readonly IEstoqueEventoRepository _estoqueEventoRepository;
    private readonly IMapper _mapper;

    public EstoqueEventoService (IEstoqueEventoRepository estoqueEventoRepository, IMapper mapper)
    {
        _estoqueEventoRepository = estoqueEventoRepository;
        _mapper = mapper;
    }

    public EstoqueEvento Create(CreateEstoqueEventoDto estoqueEventoDto)
    {
        var estoqueEvento = _mapper.Map<EstoqueEvento>(estoqueEventoDto);
        return _estoqueEventoRepository.Create(estoqueEvento);
    }
}