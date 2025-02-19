using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Profiles;
using backend.person.datalibrary.Repository;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using backend.person.modellibrary.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Services;

public class EstoqueEventoService(IPersonDataContext context) : IEstoqueEventoService
{
    

    public EstoqueEvento Create(EstoqueEvento estoqueEvento)
    {
        context.EstoqueEvento.Add(estoqueEvento);
        context.SaveChanges();
        return estoqueEvento;
        
    }
    

    public EstoqueEvento GetByPk(int id)
    {
        try
        {
            return context.EstoqueEvento.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public EstoqueEvento Update(int id, EstoqueEvento estoqueEvento)
    {
        var estoqueeventoAtualizado = GetByPk(id);
        estoqueeventoAtualizado.Descricao = estoqueEvento.Descricao;
        context.SaveChanges();
        return estoqueeventoAtualizado;
    }

    public EstoqueEvento Delete(int id)
    {
        var estoqueevento = GetByPk(id);
        context.EstoqueEvento.Remove(estoqueevento);
        context.SaveChanges();
        return estoqueevento;
    }

    public PagedList<EstoqueEvento> GetList(int[]? ids, string? descricao, int page =0, int pageSize = 0)
    {
        
        var query =
            from estoqueEvento in context.EstoqueEvento
            where
                (ids == null || ids.Length == 0 || ids.Contains(estoqueEvento.Id))
                &&(descricao == null || estoqueEvento.Descricao == descricao)
            select estoqueEvento;
        
        return PagedList<EstoqueEvento>.Create(query, page, pageSize);
    }

    public PagedList<VwRelatorioEstoque> GetVwRelatorioEstoque (int[]? idsProduto)
    {
        var queryProduto =
            from produto in context.Produto
            where
                (idsProduto == null || idsProduto.Length == 0 || idsProduto.Contains(produto.Id))
            
            select new VwRelatorioEstoque
            {
                IdProduto = produto.Id,
                DescricaoProduto = produto.Descricao,
                SaldoQuantidade = 0,
                SaldoValor = 0
            };
       
        
        var queryEstoqueMovimento =
            from estoqueMovimento in context.EstoqueMovimento
            where
                (idsProduto == null || idsProduto.Length == 0 || idsProduto.Contains(estoqueMovimento.IdProduto))
            select estoqueMovimento;
         
       
        var listaProdutos = queryProduto.ToList();
        var listaEstoqueMovimentos = queryEstoqueMovimento.ToList();

        foreach (var produto in listaProdutos)
        {
            produto.SaldoQuantidade = 
                listaEstoqueMovimentos
                    .Where(x => x.IdProduto == produto.IdProduto)
                    .Sum(x => x.Quantidade);
             
            produto.SaldoValor = 
                listaEstoqueMovimentos
                    .Where(x => x.IdProduto == produto.IdProduto)
                    .Sum(x => x.Valor);
        }

        return PagedList<VwRelatorioEstoque>.Create(queryProduto);

    }
    
}