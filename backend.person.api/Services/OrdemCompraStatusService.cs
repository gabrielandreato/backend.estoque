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
   

    public OrdemCompraStatusService(IOrdemCompraStatusRepository ordemCompraStatusRepository)
    {
        _ordemCompraStatusRepository = ordemCompraStatusRepository;
      
    }

    public OrdemCompraStatus Create(OrdemCompraStatus ordemCompraStatus)
    {
       
       return _ordemCompraStatusRepository.Create(ordemCompraStatus);
        
    }
    
    public PagedList<OrdemCompraStatus> GetList(string? ids, string? descricao,
        int page, int pageSize )
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _ordemCompraStatusRepository.GetList(splittedIds, descricao, page, pageSize);
    }

    public OrdemCompraStatus Update(int id, OrdemCompraStatus ordemCompraStatus)
    {
        return _ordemCompraStatusRepository.Update(id, ordemCompraStatus);
       
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