using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Request;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services.Interfaces;

public interface IEnderecoService
{
    Endereco Create(Endereco endereco);

    Endereco GetByPk(int id);
    
    Endereco Update(int id, Endereco endereco);
    
    Endereco Remove(int id);

    List<Endereco> RemoveByCustomer(int idCliente);
    PagedList<Endereco> GetList(GetEnderecoRequest getEnderecoRequest);
}