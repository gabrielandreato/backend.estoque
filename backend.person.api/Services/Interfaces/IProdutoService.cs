using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using backend.person.modellibrary.ViewModel;

namespace backend.person.api.Services.Interfaces
{
    public interface IProdutoService
    {
        Produto Create(CreateProdutoDto produtoDto);

        Produto GetByPk(int id);

        Produto Remove(int id);
        
        Produto Update (int id, UpdateProdutoDto updateProdutoDto);
        PagedList<Produto> GetList(string? ids, string? descricao,
        int page, int pageSize, int? idMarca);
        
        PagedList<VwProduto> GetVw(string? ids, string? descricao,
            int page, int pageSize, int? idMarca, int? idCategoria);

    }
}
