using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IProdutoCorService
{
   ProdutoCor Create(ProdutoCor produtoCor);

   ProdutoCor GetByPk(int id);
   
   ProdutoCor Update(int id,ProdutoCor produtoCor);
   
   ProdutoCor Delete (int id);
   PagedList<ProdutoCor>GetList (string? ids,int? idProduto, int? idCor,
      int page, int pageSize);
   
}