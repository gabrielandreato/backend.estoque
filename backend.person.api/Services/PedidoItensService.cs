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
    

    public PedidoItensService(IPedidoItensRepository pedidoItensRepository)
    {
        _pedidoItensRepository = pedidoItensRepository;
       
    }

    public PedidoItens Create (PedidoItens pedidoItens)
    {
        var pedidoItensCriado = new PedidoItens
        {
            Quantidade = pedidoItens.Quantidade,
            IdProduto = pedidoItens.IdProduto,
            IdPedido = pedidoItens.IdPedido,
        };
        return _pedidoItensRepository.Create(pedidoItensCriado);
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