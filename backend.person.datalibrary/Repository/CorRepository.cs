using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class CorRepository : ICorRepository
{
    private readonly IPersonDataContext _context;
    private readonly IMapper _mapper;

    public CorRepository(IPersonDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Cor Create(Cor cor)
    {
        _context.Cor.Add(cor);
        _context.SaveChanges();
        return cor;
    }

    public Cor GetByPK(int id)
    {
        try
        {
            return _context.Cor.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new  ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }

    public Cor Remove(int id)
    {
        var cor = GetByPK(id);
        _context.Cor.Remove(cor);
        _context.SaveChanges();
        return cor;
    }

    public Cor Update(int id, UpdateCorDto updateCorDto)
    {
        var cor = GetByPK(id);
        _mapper.Map(updateCorDto, cor );
        _context.SaveChanges();
        return cor;
    }
    
    public PagedList<Cor> GetList(int[]? ids = null, string? descricao = null, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from cor in _context.Cor
            where 
                (ids == null || ids.Length == 0 || ids.Contains(cor.Id))
                && (descricao == null || descricao == cor.Descricao)
            select cor;

        return PagedList<Cor>.Create(query, page, pageSize);
    }
    
}