using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using backend.person.modellibrary.ViewModel;

namespace backend.person.api.Services
{
    public class ProdutoService(IPersonDataContext context) : IProdutoService
    {

        public Produto Create(Produto produto)
        {
            context.Produto.Add(produto);
            context.SaveChanges();
            return produto;

        }

        public Produto GetByPk(int id)
        {
            try
            {
                return context.Produto.First(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Não foi possivel encontrar o Id", e);
            }
        }

        public Produto Remove(int id)
        {
            var produto = GetByPk(id);
            context.Produto.Remove(produto);
            context.SaveChanges();
            return produto;
        }


        public Produto Update(int id, Produto produto)
        {
            var produtoAtualizado = GetByPk(id);
            produtoAtualizado.Descricao = produto.Descricao;
            produtoAtualizado.IdCategoria = produto.IdCategoria;
            produtoAtualizado.IdMarca = produto.IdMarca;
            return produtoAtualizado;
        }

        public PagedList<Produto> GetList(string? ids = null, string? descricao = null,
            int page = 0, int pageSize = 0, int? idMarca = null, int? idCategoria = null, int? idMaterial = null)
        {
            var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
            
            var query =
                from produto in context.Produto
                where
                    (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(produto.Id))
                    && (descricao == null || descricao == produto.Descricao)
                    && (idMarca == null || idMarca == produto.IdMarca)
                    && (idCategoria == null || idCategoria == produto.IdCategoria)
                    && (idMaterial == null || idMaterial == produto.IdMaterial)
                select produto;

            return PagedList<Produto>.Create(query, page, pageSize);
        }
        public PagedList<VwProduto> GetVw(string? ids = null, string? descricao = null, 
            int page = 0, int pageSize = 0, int? idMarca = null,int? idCategoria = null, int? idMaterial= null)
        {
            
            var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
            
            var query =
                from produto in context.Produto
                join marca in context.Marca on produto.IdMarca equals marca.Id
                join produtoCategoria in context.ProdutoCategoria on produto.IdCategoria equals produtoCategoria.Id
                where
                    (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(produto.Id))
                    && (descricao == null || descricao == produto.Descricao)
                    && (idMarca == null || idMarca == produto.IdMarca)
                    && (idCategoria == null || idCategoria == produto.IdCategoria)
                    && (idMaterial == null || idMaterial == produto.IdMaterial)

                select new VwProduto()
                {
                    Id = produto.Id,
                    Descricao = produto.Descricao,
                    IdMarca = produto.IdMarca,
                    DescricaoMarca = marca.Descricao,
                    IdCategoria = produto.IdCategoria,
                    DescricaoCategoria = produtoCategoria.DescCategoria,
                };

            return PagedList<VwProduto>.Create(query, page, pageSize);
        }

    }
}
