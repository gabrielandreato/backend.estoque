using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

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
    
    
}