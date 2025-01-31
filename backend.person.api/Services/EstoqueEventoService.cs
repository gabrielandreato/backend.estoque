using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Profiles;
using backend.person.datalibrary.Repository;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using Microsoft.AspNetCore.Mvc;

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

    public EstoqueEvento GetByPk(int id)
    {
        return _estoqueEventoRepository.GetByPk(id);
    }

    public EstoqueEvento Update(int id, EstoqueEvento estoqueEvento)
    {
        return _estoqueEventoRepository.Update(id, estoqueEvento);
    }

    public EstoqueEvento Delete(int id)
    {
        return _estoqueEventoRepository.Delete(id);
    }

    public PagedList<EstoqueEvento> GetList(string? ids, string descricao, int page, int pageSize)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _estoqueEventoRepository.GetList(splittedIds,descricao , page, pageSize);
    }
    
}