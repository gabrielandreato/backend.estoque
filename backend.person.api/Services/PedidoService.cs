using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IMapper _mapper;

    public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
    {
        _pedidoRepository = pedidoRepository;
        _mapper = mapper;
    }

    public Pedido Create (CreatePedidoDto pedidoDto)
    {
       var pedido = _mapper.Map<Pedido>(pedidoDto);
       return _pedidoRepository.Create(pedido);
    }
    
    public Pedido GetByPk(int id)
    {
        return _pedidoRepository.GetByPk(id);
    }

    public Pedido Update (int id, UpdatePedidoDto pedidoDto)
    {
        return _pedidoRepository.Update(id, pedidoDto);
    }

    public Pedido Remove(int id)
    {
        return _pedidoRepository.Remove(id);
    }

    public PagedList<Pedido> GetList(string? ids, string observacao, int idPedidoStatus, int page, int pageSize)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _pedidoRepository.GetList(splittedIds,observacao,idPedidoStatus, page, pageSize);
    }
    
    
}