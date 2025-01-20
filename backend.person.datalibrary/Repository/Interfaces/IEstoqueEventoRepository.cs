using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.datalibrary.Repository;

public interface IEstoqueEventoRepository
{
    EstoqueEvento Create(EstoqueEvento estoqueEvento);
}