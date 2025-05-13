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
        pedidoDoBanco.Observacao = pedido.Observacao;
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
    
    public PagedList<Pedido> GetList (string? ids = null ,
        string? observacao = null , int? idPedidoStatus = null , int? idCliente = null ,decimal?
            precoBruto = null , string? formaDePagamento = null ,decimal? desconto = null ,decimal? taxas = null , int page = 0, int pageSize = 0)
    {
        
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        
        var query =
            from pedido in context.Pedido
            where
                (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(pedido.Id))
            &&(observacao == null || observacao == pedido.Observacao)
            &&(idPedidoStatus == null || idPedidoStatus == pedido.IdPedidoStatus)  
            &&(idCliente == null || idCliente == pedido.IdCliente)
            &&(precoBruto == null || precoBruto == pedido.PrecoBruto)
            &&(formaDePagamento == null || formaDePagamento == pedido.FormaDePagamento)
            &&(desconto == null || desconto == pedido.Desconto)
            &&(taxas == null || taxas == pedido.Taxas)    
            select pedido;

        return PagedList<Pedido>.Create(query, page, pageSize);
    }

    

    public Pedido PedidoComItens (CreatePedidoComItensDto pedidoItensDto)
    {
        var pedidoDto = new Pedido()
        {
          IdPedidoStatus = pedidoItensDto.IdPedidoStatus,
          Observacao = pedidoItensDto.Observacao,
          Desconto = pedidoItensDto.Desconto,
          IdCliente = pedidoItensDto.IdCliente,
          FormaDePagamento = pedidoItensDto.FormaDePagamento,
          PrecoBruto = pedidoItensDto.PrecoBruto,
           
        };
        
        var pedido = Create(pedidoDto);

        foreach (var item in pedidoItensDto.ListaPedidoItens)
        {
            var pedidoitens = new PedidoItens()
            {
               IdPedido = pedido.Id, 
               Quantidade = item.Quantidade,
                Preco = item.Preco,
              
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
            Observacao = pedido.Observacao,
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