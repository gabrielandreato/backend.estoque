using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.api.Services.Interfaces;

public interface IEstoqueEventoService
{
    EstoqueEvento Create(CreateEstoqueEventoDto estoqueEventoDto);
}