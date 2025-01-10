using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class MarcaService : IMarcaService
{
    private readonly IMarcaRepository _marcaRepository;
    private readonly IMapper _mapper;

    public MarcaService(IMarcaRepository marcaRepository, IMapper mapper)
    {
        _marcaRepository = marcaRepository;
        _mapper = mapper;
    }

    public Marca Create(CreateMarcaDto marcaDto)
    {
        var marca = _mapper.Map<Marca>(marcaDto);
        return _marcaRepository.Create(marca);
    }

    public Marca GetByPk(int id)
    {
        return _marcaRepository.GetByPk(id);
    }

    public Marca Remove(int id)
    {
        return _marcaRepository.Remove(id);
    }
    public Marca Update (int id, UpdateMarcaDto updateMarcaDto)
    {
        return _marcaRepository.Update(id, updateMarcaDto);
    }
    
    public PagedList<Marca> GetList(string? ids, string? descricao,
        int page, int pageSize)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _marcaRepository.GetList(splittedIds, descricao, page, pageSize);
    }
    
    
}