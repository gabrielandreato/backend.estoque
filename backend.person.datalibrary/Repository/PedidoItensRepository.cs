using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class PedidoItensRepository : IPedidoItensRepository
{
    private readonly IPersonDataContext _context;
   

    public PedidoItensRepository(IPersonDataContext context)
    {
        _context = context;
        
    }


    public PedidoItens Create(PedidoItens pedidoItens)
    {
        _context.PedidoItens.Add(pedidoItens);
        _context.SaveChanges();
        return pedidoItens;
    }

    public PedidoItens GetByPk(int id)
    {
        try
        {
            var pedidoItens = _context.PedidoItens.First(x => x.Id == id);
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
        pedidoItensAtualizado.IdProduto = pedidoItensDto.IdProduto;
        _context.SaveChanges();
        return pedidoItensAtualizado;
    } 
    
    public PagedList<PedidoItens> GetList(int[]? ids, int? idPedido,int? idProduto, int? quantidade, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from pedidoitens in _context.PedidoItens
            where

                (ids == null || ids.Length == 0 || ids.Contains(pedidoitens.Id))
            && (idPedido == null || idPedido == pedidoitens.IdPedido)
                && (idProduto == null || idProduto == pedidoitens.IdProduto)
                &&(quantidade == null || quantidade == pedidoitens.Quantidade)
                
            select pedidoitens;

        return PagedList<PedidoItens>.Create(query, page, pageSize);
    }
    
    
    
}