using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class PedidoItensService(IPersonDataContext context) : IPedidoItensService
{
    
    public PedidoItens Create (PedidoItens pedidoItens)
    {
        context.PedidoItens.Add(pedidoItens);
        context.SaveChanges();
        return pedidoItens;
    }

    public PedidoItens GetByPk(int id)
    {
        try
        {
            var pedidoItens = context.PedidoItens.First(x => x.Id == id);
            return pedidoItens;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public PedidoItens Update(int id, UpdatePedidoItensDto pedidoItensDto)
    {
        var pedidoItensAtualizado = GetByPk(id);
        pedidoItensAtualizado.IdPedido = pedidoItensDto.IdPedido;
        pedidoItensAtualizado.Quantidade = pedidoItensDto.IdPedido;
        context.SaveChanges();
        return pedidoItensAtualizado;
    }

    public PagedList<PedidoItens> GetList (int[]? ids, int? idPedido,int? idProduto, int? quantidade, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from pedidoitens in context.PedidoItens
            where

                (ids == null || ids.Length == 0 || ids.Contains(pedidoitens.Id))
                && (idPedido == null || idPedido == pedidoitens.IdPedido)
                &&(quantidade == null || quantidade == pedidoitens.Quantidade)
                
            select pedidoitens;

        return PagedList<PedidoItens>.Create(query, page, pageSize);
    }
    
    

}