using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class EmailService(IPersonDataContext context):IEmailService
{
     public Email Create(Email email)
    {
        context.Email.Add(email);
        context.SaveChanges();
        return email;
    }


    public Email GetByPk(int id)
    {
        try
        {
            return context.Email.First(x => x.id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o email");
        }
    }


    public Email Update(int id, Email email)
    {
        var emailAtualizado = GetByPk(id);
        emailAtualizado.EmailCliente = email.EmailCliente;
        context.SaveChanges();
        return emailAtualizado;
    }

    public Email Remove(int id)
    {
        var emailAtualizado = GetByPk(id);
        context.Email.Remove(emailAtualizado);
        context.SaveChanges();
        return emailAtualizado;
    }



     public PagedList<Email> GetList (string? ids, int? idCliente, string? emailCliente, int page = 0, int pageSize = 0)
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        
        var query =
            from email in context.Email
            where
                (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(email.id))
                &&(idCliente == null || idCliente == email.idCliente)
                && (emailCliente == null || emailCliente == email.EmailCliente)
            select email;
        return PagedList<Email>.Create(query, page, pageSize);
    }
    
    
    
    
    
    
}