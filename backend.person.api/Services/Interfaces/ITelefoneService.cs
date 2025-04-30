using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface ITelefoneService
{
    Telefone Create(Telefone telefone);
    Telefone GetByPk(int id);
    
    Telefone Update(int id, Telefone telefone);
    
    Telefone Remove(int id);
    PagedList<Telefone> GetList(int[]? ids, string? telefones, int? idCliente, int page, int pageSize);
}