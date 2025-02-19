using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IProdutoCategoriaRepository
{
    ProdutoCategoria Create (ProdutoCategoria produtocategoria);
    
    ProdutoCategoria GetByPk(int id);
    
    ProdutoCategoria Remove(int id);
    
    ProdutoCategoria Update(int id,ProdutoCategoria produtoCategoria);
    
    PagedList<ProdutoCategoria> GetList(int[]? ids = null, string? descricao = null, 
        int page = 0, int pageSize = 0);
    
}