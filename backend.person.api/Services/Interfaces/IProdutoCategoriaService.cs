using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

 public interface IProdutoCategoriaService
 {
     ProdutoCategoria Create(CreateProdutoCategoriaDto produtoCategoriaDto);
     
     ProdutoCategoria GetByPk(int id);
     
     ProdutoCategoria Remove (int id);
     
     ProdutoCategoria Update(int id, UpdateProdutoCategoriaDto produtoCategoriaDto);
     
     PagedList<ProdutoCategoria> GetList (string? ids, string? descricao,
         int page, int pageSize);
 }