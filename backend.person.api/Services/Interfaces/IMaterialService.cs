using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IMaterialService
{
    Material Create(Material material);
    Material GetByPk(int id);
    Material Update(int id, Material material);
    Material Remove(int id);
    
    PagedList<Material> GetList (string? ids, string? descricao, int page, int pageSize);
}