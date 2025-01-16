using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IMarcaService
{
    Marca Create(CreateMarcaDto marcaDto);
    Marca GetByPk(int id);

    Marca Remove(int id);
    
    Marca Update(int id, UpdateMarcaDto updateMarcaDto);

    PagedList<Marca> GetList(string? ids, string? descricao,
        int page, int pageSize);
    
    
    
}