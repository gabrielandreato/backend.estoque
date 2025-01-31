using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class EstoqueEventoRepository: IEstoqueEventoRepository
{
    private readonly IPersonDataContext _context;
    private readonly IMapper _mapper;

    public EstoqueEventoRepository(IPersonDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public EstoqueEvento Create(EstoqueEvento estoqueEvento)
    {
        _context.EstoqueEvento.Add(estoqueEvento);
        _context.SaveChanges();
        return estoqueEvento;
    }

    public EstoqueEvento GetByPk(int id)
    {
        try
        {
            return _context.EstoqueEvento.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public EstoqueEvento Update(int id, EstoqueEvento estoqueEvento)
    {
        var estoqueevento = GetByPk(id);
        
        estoqueevento.Descricao = estoqueEvento.Descricao;
        _context.SaveChanges();
        return estoqueevento;
    }

    public EstoqueEvento Delete(int id)
    {
        var estoqueevento = GetByPk(id);
        _context.EstoqueEvento.Remove(estoqueevento);
        _context.SaveChanges();
        return estoqueevento;
    }

    
    public PagedList<EstoqueEvento> GetList(int[]? ids, string? descricao, int page =0, int pageSize = 0)
    {
        
        var query =
            from estoqueEvento in _context.EstoqueEvento
            where
                (ids == null || ids.Length == 0 || ids.Contains(estoqueEvento.Id))
               &&(descricao == null || estoqueEvento.Descricao == descricao)
            select estoqueEvento;
        
        return PagedList<EstoqueEvento>.Create(query, page, pageSize);
    }
    
    
}