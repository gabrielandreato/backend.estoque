using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class PedidoStatusService(IPersonDataContext context) : IPedidoStatusService
{
  
   public PedidoStatus Create(PedidoStatus pedidoStatus)
   {
      context.PedidoStatus.Add(pedidoStatus);
      context.SaveChanges();
      return pedidoStatus;
   }

   public PedidoStatus GetByPk(int id)
   {
      try
      {
         var pedidostatus = context.PedidoStatus.First(x => x.Id == id);
         return pedidostatus;
      }
      catch (Exception e)
      {
         throw new ApplicationException("Não foi possivel encontrar o Id", e);
      }
   }

   public PedidoStatus Update(int id, PedidoStatus pedidoStatus)
   {
      var pedidoStatusDobanco = GetByPk(id);
      pedidoStatusDobanco.Descricao = pedidoStatus.Descricao;
      context.SaveChanges();
      return pedidoStatusDobanco;
   }

   public PedidoStatus Remove(int id)
   {
      var pedidoStatus = GetByPk(id);
      context.PedidoStatus.Remove(pedidoStatus);
      context.SaveChanges();
      return pedidoStatus;
   }
    
   public PagedList<PedidoStatus> GetList(string? ids = null , string? descricao= null ,
      int page = 0, int pageSize = 0)
   {
      
      var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
      
      
      var query =
         from pedidostatus in context.PedidoStatus
         where
            (splittedIds == null || splittedIds.Length == 0 || splittedIds.Contains(pedidostatus.Id))
            && (descricao == null || descricao == pedidostatus.Descricao)
         select pedidostatus;

      return PagedList<PedidoStatus>.Create(query, page, pageSize);
   }
   
   
}