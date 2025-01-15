using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface ICorService
{
    Cor Create (CreateCorDto cor);
    
    Cor GetByPk (int id);
    
    Cor Remove (int id);
    
    Cor Update (int id, UpdateCorDto cor);
    
    PagedList<Cor>GetList(string ids, string? descricao,int page,int pageSize);
    
}