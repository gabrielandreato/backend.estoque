using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

 public interface IProdutoCategoriaService
 {
     ProdutoCategoria Create(ProdutoCategoria produtoCategoria);
     
     ProdutoCategoria GetByPk(int id);
     
     ProdutoCategoria Remove (int id);
     
     ProdutoCategoria Update(int id, ProdutoCategoria produtoCategoria);
     
     PagedList<ProdutoCategoria> GetList (string? ids, string? descCategoria,
         int page, int pageSize);
 }