using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IClienteService 
{
    Cliente Create(Cliente cliente);
    
    Cliente GetByPk(int id);
    
    Cliente Update(int id, Cliente cliente);
    
    Cliente Remove(int id);
    
    PagedList<Cliente> GetList(string? ids, string? nome, DateTime? dataNascimento, string? cpf, int page, int pageSize);
}