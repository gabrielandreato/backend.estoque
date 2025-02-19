using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface ICorService
{
    Cor Create (Cor cor);
    
    Cor GetByPk (int id);
    
    Cor Remove (int id);
    
    Cor Update (int id, Cor cor);
    
    PagedList<Cor>GetList(int[]? ids = null, string? descricao = null, 
        int page = 0, int pageSize = 0);
    
}