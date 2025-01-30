using AutoMapper;
using backend.person.datalibrary.DataContext;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.datalibrary.Repository;

public class OrdemCompraRepository : IOrdemCompraRepository
{
    private readonly IPersonDataContext _context;
    private readonly IMapper _mapper;

    public OrdemCompraRepository(IPersonDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public OrdemCompra Create (OrdemCompra ordemCompra)
    {
        _context.OrdemCompra.Add(ordemCompra);
        _context.SaveChanges();
        return ordemCompra;
    }

    public OrdemCompra GetByPk(int id)
    {
        try
        {
            var ordemCompra = _context.OrdemCompra.First(x => x.Id == id);
            return ordemCompra;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Não foi possivel encontrar o Id", e);
        }
    }
    
    

    public OrdemCompra Update(int id, UpdateOrdemCompraDto ordemCompraDto)
    {
        var ordemCompra = GetByPk(id);
        _mapper.Map(ordemCompraDto, ordemCompra);
        _context.SaveChanges();
        return ordemCompra;
        
        
    }

    public OrdemCompra Remove(int id)
    {
        var ordemCompra = GetByPk(id);
        _context.OrdemCompra.Remove(ordemCompra);
        _context.SaveChanges();
        return ordemCompra;
    }
    
    public PagedList<OrdemCompra> GetList(int[]? ids, int? idproduto, int? valor, int? idOrdemCompraStatus, 
        int page = 0, int pageSize = 0)
    {
        var query =
            from ordemCompra in _context.OrdemCompra
            where
                (ids == null || ids.Length == 0 || ids.Contains(ordemCompra.Id))
                &&(idproduto == null || idproduto == ordemCompra.Id)
                &&(valor == null || valor == ordemCompra.Valor)
                &&(idOrdemCompraStatus ==null || idOrdemCompraStatus == ordemCompra.IdOrdemCompraStatus)
               
                
                
            select ordemCompra;

        return PagedList<OrdemCompra>.Create(query, page, pageSize);
    }
    
    
}