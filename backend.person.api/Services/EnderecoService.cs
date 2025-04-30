using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Request;
using backend.person.modellibrary.Utils;
using Microsoft.AspNetCore.Http.HttpResults;

namespace backend.person.api.Services;

public class EnderecoService(IPersonDataContext context) : IEnderecoService
{
    public Endereco Create(Endereco endereco)
    {
        if (endereco.EnderecoPrincipal == true)
        {
            var enderecoPrincipal = context.Endereco
                .FirstOrDefault(x => x.IdCliente == endereco.IdCliente && x.EnderecoPrincipal == true);

            if (enderecoPrincipal?.EnderecoPrincipal!= null ) enderecoPrincipal.EnderecoPrincipal = false;
        }

        context.Endereco.Add(endereco);
        context.SaveChanges();
        return endereco;
    }

    public Endereco GetByPk(int id)
    {
        try
        {
            return context.Endereco.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o email");
        }
    }

    public Endereco Update(int id, Endereco endereco)
    {
        var enderecoAtualizado = GetByPk(id);
        enderecoAtualizado.EnderecoPrincipal = endereco.EnderecoPrincipal;
        enderecoAtualizado.Bairro = endereco.Bairro;
        enderecoAtualizado.Cidade = endereco.Cidade;
        enderecoAtualizado.Rua = endereco.Rua;
        enderecoAtualizado.CEP = endereco.CEP;
        context.SaveChanges();
        return enderecoAtualizado;
    }

    public Endereco Remove(int id)
    {
        var endereco = GetByPk(id);
        context.Endereco.Remove(endereco);
        context.SaveChanges();
        return endereco;
    }

    public List<Endereco> RemoveByCustomer(int idCliente)
    {
        var enderecosDoCliente = context.Endereco
            .Where(x => x.IdCliente == idCliente).ToList();

        foreach (var endereco in enderecosDoCliente)
        {
            context.Endereco.Remove(endereco);
        }

        context.SaveChanges();
        return enderecosDoCliente;
    }


    public PagedList<Endereco> GetList(GetEnderecoRequest getEnderecoRequest)
    {
        
        var splittedIds = Array.ConvertAll(getEnderecoRequest.Ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        
        var query =
            from endereco in context.Endereco
            where
                (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(endereco.Id))
                && (getEnderecoRequest.Bairro == null || getEnderecoRequest.Bairro == endereco.Bairro)
                && (getEnderecoRequest.idCliente == null || getEnderecoRequest.idCliente == endereco.IdCliente)
                && (getEnderecoRequest.Cidade == null || getEnderecoRequest.Cidade == endereco.Cidade)
                && (getEnderecoRequest.Cep == null || getEnderecoRequest.Cep == endereco.CEP)
                && (getEnderecoRequest.idEstado == null || getEnderecoRequest.idEstado == endereco.IdEstado)
                && (getEnderecoRequest.idPais == null || getEnderecoRequest.idPais == endereco.IdPais)
                && (getEnderecoRequest.EnderecoPrincipal || getEnderecoRequest.EnderecoPrincipal == endereco.EnderecoPrincipal)
            select endereco;
        return PagedList<Endereco>.Create(query);
    }
    
    
}