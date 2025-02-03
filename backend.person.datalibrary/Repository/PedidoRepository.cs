using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class PedidoRepository : IPedidoRepository
{
    private readonly PersonDataContext _context;
    private readonly IMapper _mapper;

    public PedidoRepository(PersonDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Pedido Create(Pedido pedido)
    {
        _context.Pedido.Add(pedido);
        _context.SaveChanges();
        return pedido;
    }

    public Pedido GetByPk(int id)
    {
        try
        {
            var pedido = _context.Pedido.First(x => x.Id == id);
            return pedido;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public Pedido Update(int id, UpdatePedidoDto pedidoDto)
    {
        var pedido = GetByPk(id);
        _mapper.Map(pedidoDto, pedido);
        _context.SaveChanges();
        return pedido;
    }

    public Pedido Remove(int id)
    {
        var pedido = GetByPk(id);
        _context.Pedido.Remove(pedido);
        _context.SaveChanges();
        return pedido;
    }

    public PagedList<Pedido> GetList(int[]? ids, string? observacao, int? idPedidoStatus,
        int page = 0, int pageSize = 0)
    {
        var query =
            from pedido in _context.Pedido
            where

                (ids == null || ids.Length == 0 || ids.Contains(pedido.Id))
                && (observacao == null || observacao == pedido.Observacao)
                && (idPedidoStatus == null || idPedidoStatus == pedido.IdPedidoStatus)

            select pedido;

        return PagedList<Pedido>.Create(query, page, pageSize);
    }


    
}