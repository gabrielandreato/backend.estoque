using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class PedidoStatusService : IPedidoStatusService
{
   private readonly IPedidoStatusRepository _pedidoStatusRepository;

   public PedidoStatusService(IPedidoStatusRepository pedidoStatusRepository)
   {
      _pedidoStatusRepository = pedidoStatusRepository;
   }

   public PedidoStatus Create(PedidoStatus pedidoStatus)
   {
      return _pedidoStatusRepository.Create(pedidoStatus);
   }

   public PedidoStatus GetByPk(int id)
   {
      return _pedidoStatusRepository.GetByPk(id);
   }

   public PedidoStatus Update(int id, PedidoStatus pedidoStatusDto)
   {
      return _pedidoStatusRepository.Update(id, pedidoStatusDto);
   }

   public PedidoStatus Remove(int id)
   {
      return _pedidoStatusRepository.Remove(id);
   }
    
   public PagedList<PedidoStatus> GetList(string? ids,string observacao,  
      int page, int pageSize )
   {
      var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
      return _pedidoStatusRepository.GetList(splittedIds,observacao, page, pageSize);
   }
   
   
   
}