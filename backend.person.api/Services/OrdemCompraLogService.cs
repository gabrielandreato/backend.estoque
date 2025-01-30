using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class OrdemCompraLogService: IOrdemCompraLogSerivce
{
    private readonly IOrdemCompraLogRepository _ordemCompraLogRepository;
    private readonly IMapper _mapper;

    public OrdemCompraLogService(IOrdemCompraLogRepository ordemCompraLogRepository, IMapper mapper)
    {
        _ordemCompraLogRepository = ordemCompraLogRepository;
        _mapper = mapper;
    }

    public OrdemCompraLog Create(CreateOrdemCompraLogDto ordemCompraLogDto)
    {
        var ordemCompraLog = _mapper.Map<OrdemCompraLog>(ordemCompraLogDto);
        ordemCompraLog.DtLog =DateTime.Now;
        return _ordemCompraLogRepository.Create(ordemCompraLog);
    }


    public OrdemCompraLog GetByPk(int id)
    {
        return _ordemCompraLogRepository.GetByPk(id);
    }


    public OrdemCompraLog Update(int id, UpdateOrdemCompraLogDto ordemCompraLogDto)
    {
        return _ordemCompraLogRepository.Update(id, ordemCompraLogDto);
    }

    public OrdemCompraLog Remove(int id)
    {
        return _ordemCompraLogRepository.Remove(id);
    }
        
    public PagedList<OrdemCompraLog> GetList (string? ids,int idOrdemCompra, int idordemCompraStatus,
        int page, int pageSize )
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _ordemCompraLogRepository.GetList(splittedIds,idOrdemCompra,idordemCompraStatus,page,pageSize);
    }
}