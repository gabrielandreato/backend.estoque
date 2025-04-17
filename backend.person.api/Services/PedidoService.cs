using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Enum;
using backend.person.modellibrary.Utils;
using Microsoft.EntityFrameworkCore;

namespace backend.person.api.Services;

public class PedidoService(IPersonDataContext context,IPedidoItensService pedidoItensService, IPedidoLogService pedidoLogService) : IPedidoService
{
   
    

    public Pedido Create (Pedido pedido)
    {
        context.Pedido.Add(pedido);
        context.SaveChanges();
        return pedido;
    }
    
    public Pedido GetByPk(int id)
    {
        try
        {
            var pedido = context.Pedido.First(x => x.Id == id);
            return pedido;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public Pedido Update (int id, Pedido pedido)
    {
        var pedidoDoBanco = GetByPk(id);
        pedidoDoBanco.IdPedidoStatus = pedido.IdPedidoStatus;
        pedidoDoBanco.Descricao = pedido.Descricao;
        context.SaveChanges();
        return pedidoDoBanco;
    }

    public Pedido Remove(int id)
    {
        var pedido = GetByPk(id);
        context.Pedido.Remove(pedido);
        context.SaveChanges();
        return pedido;
    }
    
    public PagedList<Pedido> GetList (int[]? ids, string? observacao, int? idPedidoStatus,
        int page = 0, int pageSize = 0)
    {
        var query =
            from pedido in context.Pedido
            where

                (ids == null || ids.Length == 0 || ids.Contains(pedido.Id))
                && (observacao == null || observacao == pedido.Descricao)
                && (idPedidoStatus == null || idPedidoStatus == pedido.IdPedidoStatus)

            select pedido;

        return PagedList<Pedido>.Create(query, page, pageSize);
    }

    

    public Pedido PedidoComItens (CreatePedidoComItensDto pedidoItensDto)
    {
        var pedidoDto = new Pedido()
        {
            IdCategoria = pedidoItensDto.IdCategoria,
            IdMarca = pedidoItensDto.IdMarca,
            IdMaterial = pedidoItensDto.IdMaterial,
           
        };
        
        var pedido = Create(pedidoDto);

        foreach (var item in pedidoItensDto.ListaPedidoItens)
        {
            var pedidoitens = new PedidoItens()
            {
               // IdPedido = pedidoItensDto.IdPedido,
               // Quantidade = pedidoItensDto.IdPedido,
                //Preco = pedidoItensDto.IdPedido
              
            };
            var pedidoItemCriado = pedidoItensService.Create(pedidoitens);
        }
        return pedido;
    }

    public Pedido Faturar(int id)
    {
        var pedido = GetByPk(id);

       var pedidoAtualizado = Update(id, new Pedido()
        {
            Descricao = pedido.Descricao,
            IdPedidoStatus = (int)EPedidoStatus.Faturado
        });

        var pedidoLog = new PedidoLog
        {
            IdPedido = pedidoAtualizado.Id,
            IdStatus = pedidoAtualizado.IdPedidoStatus,
            DtLogPedido = DateTime.Now,
        };
        pedidoLogService.Create(pedidoLog);
        return pedidoAtualizado;
    }

    public Pedido Cancelado(int id)
    {
        var pedido = GetByPk(id);
        
        var  pedidoCancelado = Update(id, new Pedido
        {
            
            IdPedidoStatus = (int)EPedidoStatus.Cancelado
        });

        var pedidoLog = new PedidoLog
        {
            IdPedido = pedidoCancelado.Id,
            IdStatus = pedidoCancelado.IdPedidoStatus,
            DtLogPedido = DateTime.Now,
        };
        pedidoLogService.Create(pedidoLog);
        return pedidoCancelado;

    }
   
    
}