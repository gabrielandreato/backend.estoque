using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface ICorRepository
{
    Cor Create(Cor cor);

    Cor GetByPK (int id);
    
    Cor Remove(int id);
    
    Cor Update(int id,UpdateCorDto cor);
    
    PagedList <Cor> GetList(int[]? ids  = null,string? descricao = null,int page = 0, int pageSize = 0 );
}