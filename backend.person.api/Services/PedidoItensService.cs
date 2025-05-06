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
        pedidoItensAtualizado.IdProduto = pedidoItensDto.IdProduto;
        context.SaveChanges();
        return pedidoItensAtualizado;
    }

    public PagedList<PedidoItens> GetList(string? ids, int? idPedido, int? idProduto, 
        int? quantidade,int? idMaterial, int? idCategoria,int? idMarca, int page = 0  ,int pageSize = 0)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        
        var query =
            from pedidoItens in context.PedidoItens
            where
                (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(pedidoItens.Id))
                && (idPedido == null || idPedido == pedidoItens.IdPedido)
                && (idProduto == null || idProduto == pedidoItens.IdProduto)
                &&(quantidade == null || quantidade == pedidoItens.Quantidade)
                && (idMaterial == null || idMaterial == pedidoItens.IdMaterial)
                && (idCategoria == null || idCategoria == pedidoItens.IdCategoria)
                && (idMarca == null || idMarca == pedidoItens.IdMarca)
            select pedidoItens;

             return PagedList<PedidoItens>.Create(query, page, pageSize);
        
    }
    
    

}