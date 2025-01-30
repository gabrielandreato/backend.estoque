using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class PedidoItensService : IPedidoItensService
{
    private readonly IPedidoItensRepository _pedidoItensRepository;
    private readonly IMapper _mapper;

    public PedidoItensService(IPedidoItensRepository pedidoItensRepository, IMapper mapper)
    {
        _pedidoItensRepository = pedidoItensRepository;
        _mapper = mapper;
    }

    public PedidoItens Create(CreatePedidoItensDto pedidoItensDto)
    {
        var pedidoitens = _mapper.Map<PedidoItens>(pedidoItensDto);
        return _pedidoItensRepository.Create(pedidoitens);
    }

    public PedidoItens GetByPk(int id)
    {
        return _pedidoItensRepository.GetByPk(id);
    }

    public PedidoItens Update(int id, UpdatePedidoItensDto pedidoItensDto)
    {
        return _pedidoItensRepository.Update(id, pedidoItensDto);
    }


    public PagedList<PedidoItens> GetList (string? ids, int idPedido, int idProduto, int quantidade, int page = 0, int pageSize = 0)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _pedidoItensRepository.GetList(splittedIds,idPedido,idProduto,quantidade,page,pageSize);
    }

}