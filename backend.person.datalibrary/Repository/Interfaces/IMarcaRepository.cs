using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IMarcaRepository
{
    Marca Create(Marca marca);
    
    Marca GetByPk (int id);

    Marca Remove(int id);
    
    Marca Update(int id, UpdateMarcaDto updateMarcaDto);
    
    PagedList<Marca> GetList(int[]? ids = null, string? desricao = null, 
        int page = 0, int pageSize = 0);
}