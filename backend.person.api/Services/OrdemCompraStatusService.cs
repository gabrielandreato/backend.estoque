using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class OrdemCompraStatusService : IOrdemCompraStatusService
{
    private readonly IOrdemCompraStatusRepository _ordemCompraStatusRepository;
    private readonly IMapper _mapper;

    public OrdemCompraStatusService(IOrdemCompraStatusRepository ordemCompraStatusRepository, IMapper mapper)
    {
        _ordemCompraStatusRepository = ordemCompraStatusRepository;
        _mapper = mapper;
    }

    public OrdemCompraStatus Create(CreateOrdemCompraStatusDto ordemCompraStatusDto)
    {
        var ordemCompraStatus = _mapper.Map<OrdemCompraStatus>(ordemCompraStatusDto);
        return _ordemCompraStatusRepository.Create(ordemCompraStatus);
    }
    
    public PagedList<OrdemCompraStatus> GetList(string? ids, string? descricao,
        int page, int pageSize )
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _ordemCompraStatusRepository.GetList(splittedIds, descricao, page, pageSize);
    }

    public OrdemCompraStatus Update(int id, UpdateOrdemCompraStatusDto updateOrdemCompraStatusDto)
    {
       return _ordemCompraStatusRepository.Update(id,updateOrdemCompraStatusDto); 
    }

    public OrdemCompraStatus Remove(int id)
    {
        return _ordemCompraStatusRepository.Remove(id);
    }

    public OrdemCompraStatus GetByPk(int id)
    {
        return _ordemCompraStatusRepository.GetByPk(id);
    }
    
    
    
}