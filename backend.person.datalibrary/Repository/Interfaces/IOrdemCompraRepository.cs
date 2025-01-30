using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IOrdemCompraRepository
{
    OrdemCompra Create(OrdemCompra ordemCompra);

    OrdemCompra Update(int id, UpdateOrdemCompraDto updateOrdemCompraDto);
    OrdemCompra GetByPk(int id);
    
    OrdemCompra Remove(int id);

    PagedList<OrdemCompra> GetList(int[] splittedIds, int? idproduto, int? valor, int? idOrdemCompraStatus, int page, int pageSize);
}