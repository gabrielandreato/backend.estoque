using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IOrdemCompraService
{
    OrdemCompra  Create(OrdemCompra ordemCompra);

    OrdemCompra Update(int id , OrdemCompra ordemCompra);
    OrdemCompra GetByPk(int id);
    OrdemCompra Remove(int id);
    PagedList<OrdemCompra> GetList (string? ids, int? idProduto ,int? idOrdemCompraStatus, int page, int pageSize);
    OrdemCompra Aprovar (int id);
    OrdemCompra Comprar (int id);
    OrdemCompra Reprovar (int id,ReprovarOrdemCompraDto ordemCompraDto);
}