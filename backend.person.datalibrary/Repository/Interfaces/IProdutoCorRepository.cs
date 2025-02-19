using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IProdutoCorRepository
{
    ProdutoCor Create(ProdutoCor produtoCor);

    ProdutoCor GetByPk(int id);
    
    ProdutoCor Update(int id, ProdutoCor produtoCor);

    ProdutoCor Remove(int id);
    
    PagedList<ProdutoCor>GetList(int[]? ids = null,int? idProduto = null, int? idCor = null,
        int page = 0, int pageSize = 0);
}