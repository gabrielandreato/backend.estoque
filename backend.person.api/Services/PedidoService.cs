using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Enum;
using backend.person.modellibrary.Utils;
using Microsoft.EntityFrameworkCore;

namespace backend.person.api.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IPedidoItensService _pedidoItensService;
    private readonly IPedidoLogService _pedidoLogService;

    public PedidoService(IPedidoRepository pedidoRepository, IPedidoItensService pedidoItensService, IPedidoLogService pedidoLogService)
    {
        _pedidoRepository = pedidoRepository;
        ;
        _pedidoItensService = pedidoItensService;
        _pedidoLogService = pedidoLogService;
    }

    public Pedido Create (Pedido pedido)
    {
       pedido.IdPedidoStatus = (int)EPedidoStatus.Pendente;
        return _pedidoRepository.Create(pedido);
         
    }
    
    public Pedido GetByPk(int id)
    {
        return _pedidoRepository.GetByPk(id);
    }

    public Pedido Update (int id, Pedido pedido)
    {
        return _pedidoRepository.Update(id, pedido);
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

    public Pedido PedidoComItens (CreatePedidoComItensDto pedidoItensDto)
    {
        var pedidoDto = new Pedido()
        {
            Observacao = pedidoItensDto.Observacao
        };
        
        var pedido = Create(pedidoDto);

        foreach (var item in pedidoItensDto.ListaPedidoItens)
        {
            var pedidoitens = new PedidoItens()
            {
               IdProduto = item.IdProduto,
               Quantidade = item.Quantidade,
               IdPedido = pedido.Id,
            };
            var pedidoItemCriado =_pedidoItensService.Create(pedidoitens);
        }
        return pedido;
    }

    public Pedido Faturar(int id)
    {
        var pedido = _pedidoRepository.GetByPk(id);

       var pedidoAtualizado = _pedidoRepository.Update(id, new Pedido()
        {
            Observacao = pedido.Observacao,
            IdPedidoStatus = (int)EPedidoStatus.Faturado
        });

        var pedidoLog = new PedidoLog
        {
            IdPedido = pedidoAtualizado.Id,
            IdStatus = pedidoAtualizado.IdPedidoStatus,
            DtLogPedido = DateTime.Now,
        };
        _pedidoLogService.Create(pedidoLog);
        return pedidoAtualizado;
    }

    public Pedido Cancelado(int id)
    {
        var pedido = GetByPk(id);
        
        var  pedidoCancelado = _pedidoRepository.Update(id, new Pedido
        {
            Observacao = pedido.Observacao,
            IdPedidoStatus = (int)EPedidoStatus.Cancelado
        });

        var pedidoLog = new PedidoLog
        {
            IdPedido = pedidoCancelado.Id,
            IdStatus = pedidoCancelado.IdPedidoStatus,
            DtLogPedido = DateTime.Now,
        };
        _pedidoLogService.Create(pedidoLog);
        return pedidoCancelado;

    }
   
    
}