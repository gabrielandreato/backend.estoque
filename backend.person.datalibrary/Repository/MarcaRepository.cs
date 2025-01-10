using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class MarcaRepository : IMarcaRepository
{
    private readonly IPersonDataContext _context;
    private readonly IMapper _mapper;

    public MarcaRepository(IPersonDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Marca Create(Marca marca)
    {
        _context.Marca.Add(marca);
        _context.SaveChanges();
        return marca;
    }

    public Marca GetByPk(int id)
    {
        try
        {
            return _context.Marca.First(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }

    }

    public Marca Remove(int id)
    {
        var marca = GetByPk(id);
        _context.Marca.Remove(marca);
        _context.SaveChanges();
        return marca;
    }
    
    public Marca Update(int id, UpdateMarcaDto updateMarcaDto)
    {
        var marca = GetByPk(id);
        _mapper.Map(updateMarcaDto, marca);
        _context.SaveChanges();
        return marca;
    }
    
    
    
    public PagedList<Marca> GetList(int[]? ids = null, string? descricao = null, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from marca in _context.Marca
            where
                (ids == null || ids.Length == 0 || ids.Contains(marca.Id))
                && (descricao == null || descricao == marca.Descricao)
            select marca;

        return PagedList<Marca>.Create(query, page, pageSize);
    }
    
}


