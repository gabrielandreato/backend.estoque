using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using backend.person.modellibrary.ViewModel;

namespace backend.person.api.Services.Interfaces
{
    public interface IProdutoService
    {
        Produto Create(Produto produto);

        Produto GetByPk(int id);

        Produto Remove(int id);
        
        Produto Update (int id, Produto produto);
        PagedList<Produto> GetList(string? ids = null, string? descricao = null,
            int page = 0, int pageSize = 0, int? idMarca = null, int? idCategoria = null, int? idMaterial = null, string? tamanho = null);
        
        PagedList<VwProduto> GetVw (string? ids, string? descricao,
            int page, int pageSize, int? idMarca, int? idCategoria, int? idMaterial, string? tamanho = null);
    }
}
