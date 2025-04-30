using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IEmailService
{
    Email Create(Email email);
    Email GetByPk(int id);
    
    Email Update(int id, Email email);
    
    Email Remove(int id);
    PagedList<Email> GetList(string? ids, int? idCliente, string? emailCliente, int page = 0, int pageSize = 0);
}