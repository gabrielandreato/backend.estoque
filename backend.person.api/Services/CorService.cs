using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class CorService : ICorService
{
    private readonly ICorRepository _corRepository;
    private readonly  IMapper _mapper;

    public CorService(ICorRepository corRepository, IMapper mapper)
    {
        _corRepository = corRepository;
        _mapper = mapper;
    }

    public Cor Create(CreateCorDto corDto)
    {
        var cor = _mapper.Map<Cor>(corDto);
        return _corRepository.Create(cor);
    }

    public Cor GetByPk(int id)
    {
        return _corRepository.GetByPK(id);
    }


    public Cor Remove(int id)
    {
        return _corRepository.Remove(id);
    }

    public Cor Update(int id, UpdateCorDto corDto)
    {
        return _corRepository.Update(id, corDto);
    }

    public PagedList<Cor> GetList(string? ids, string? descricao, int page, int pageSize)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _corRepository.GetList(splittedIds, descricao, page, pageSize);
    }
    
}