using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Enum;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class OrdemCompraService(IPersonDataContext context, IEstoqueMovimentoService estoqueMovimentoService) : IOrdemCompraService
{
    
    public OrdemCompra Create(OrdemCompra ordemCompra)
    { 
        context.OrdemCompra.Add(ordemCompra);
        context.SaveChanges();
        return ordemCompra;
    }

    public OrdemCompra GetByPk(int id)
    {
        try
        {
            var ordemCompra = context.OrdemCompra.First(x => x.Id == id);
            return ordemCompra;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }
    
    public OrdemCompra Update (int id, OrdemCompra ordemCompra)
    {
        var ordemDeCompraAtualizada = GetByPk(id);
        ordemDeCompraAtualizada.IdOrdemCompraStatus = ordemCompra.IdOrdemCompraStatus;
        ordemDeCompraAtualizada.Observacao = ordemCompra.Observacao;
        context.SaveChanges();
        return ordemDeCompraAtualizada;
    }

    public OrdemCompra Remove(int id)
    {
        var ordemCompra = GetByPk(id);
        context.OrdemCompra.Remove(ordemCompra);
        context.SaveChanges();
        return ordemCompra;
    }
    
    public PagedList<OrdemCompra> GetList(string? ids, int? idProduto = null, int? idOrdemCompraStatus = null , 
        int page = 0, int pageSize = 0)
    {
        
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        
        var query =
            from ordemCompra in context.OrdemCompra
            where
                (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(ordemCompra.Id))
                &&(idProduto == null || idProduto == ordemCompra.IdProduto)
                 &&(idOrdemCompraStatus == null || idOrdemCompraStatus == ordemCompra.IdOrdemCompraStatus)
               select ordemCompra;
        
        return PagedList<OrdemCompra>.Create(query, page, pageSize);
    }
    public OrdemCompra Aprovar (int id)
    {
        var ordemCompra = GetByPk(id);
        
        var updateOrdemCompra = new OrdemCompra()
        {
            IdProduto = ordemCompra.IdProduto,
            Quantidade = ordemCompra.Quantidade,
            IdOrdemCompraStatus =(int)EOrdemCompraStatus.Aprovado,
            DtAprovacao = DateTime.Now,
            Observacao = ordemCompra.Observacao
        };
        return Update(id,updateOrdemCompra);
    }

    public OrdemCompra Comprar (int id)
    {
       var ordemDeCompra = GetByPk(id);

       var updateOrdemCompra = new OrdemCompra
       {
          IdProduto = ordemDeCompra.IdProduto,
          Quantidade = ordemDeCompra.Quantidade,
          IdOrdemCompraStatus = (int)EOrdemCompraStatus.Comprado,
          Observacao = ordemDeCompra.Observacao
       };
       
       var  ordemDeCompraAtualizado = Update(id, updateOrdemCompra);
       
        estoqueMovimentoService.Entrada (new EstoqueMovimento()
        {
            IdProduto = ordemDeCompra.IdProduto,
            Valor = ordemDeCompra.Valor,
            Quantidade = ordemDeCompra.Quantidade,
        });

       
        return ordemDeCompraAtualizado;
    }

    
    public OrdemCompra Reprovar(int id ,ReprovarOrdemCompraDto ordemCompraDto)
    {
        var ordemDeCompra = GetByPk(id);

        var updateOrdemCompra = new OrdemCompra
        {
           IdProduto = ordemDeCompra.IdProduto,
           Quantidade = ordemDeCompra.Quantidade,
           IdOrdemCompraStatus = (int)EOrdemCompraStatus.Reprovado,
           Observacao = ordemCompraDto.Observacao,
           Valor = ordemDeCompra.Valor
           
        };
        
        return Update(id, updateOrdemCompra);
    }
}