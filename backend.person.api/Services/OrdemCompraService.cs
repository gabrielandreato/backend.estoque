using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Enum;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services;

public class OrdemCompraService : IOrdemCompraService
{
    private readonly IOrdemCompraRepository _ordemCompraRepository;
    private readonly IMapper _mapper;
    private readonly IEstoqueMovimentoService _estoqueMovimentoService;

    public OrdemCompraService (IOrdemCompraRepository ordemCompraRepository, IMapper mapper, IEstoqueMovimentoService estoqueMovimentoService)
    {
        _ordemCompraRepository = ordemCompraRepository;
        _mapper = mapper;
        _estoqueMovimentoService = estoqueMovimentoService;
    }


    public OrdemCompra Create( CreateOrdemCompraDto ordemCompraDto)
    {
        var ordemcompra = _mapper.Map<OrdemCompra>(ordemCompraDto);
        ordemcompra.IdOrdemCompraStatus = (int)EOrdemCompraStatus.Pendente;
        return _ordemCompraRepository.Create(ordemcompra);
    }

    public OrdemCompra GetByPk(int id)
    {
        return  _ordemCompraRepository.GetByPk(id);
    }
    
    public OrdemCompra Update (int id, UpdateOrdemCompraDto ordemCompraDto)
    {
        return _ordemCompraRepository.Update(id, ordemCompraDto);
    }

    public OrdemCompra Remove(int id)
    {
        return _ordemCompraRepository.Remove(id);
    }
    
    public PagedList<OrdemCompra> GetList(string? ids, int? idproduto,int? valor,int? idOrdemCompraStatus, 
        int page, int pageSize )
    {
        var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
        return _ordemCompraRepository.GetList(splittedIds,idproduto,valor,idOrdemCompraStatus, page, pageSize);
    }
    public OrdemCompra Aprovar (int id)
    {
        var ordemCompra = _ordemCompraRepository.GetByPk(id);
        
        var updateOrdemCompra = new UpdateOrdemCompraDto
        {
            IdProduto = ordemCompra.IdProduto,
            Quantidade = ordemCompra.Quantidade,
            IdOrdemCompraStatus =(int)EOrdemCompraStatus.Aprovado,
            DtAprovacao = DateTime.Now,
            Observacao = ordemCompra.Observacao
        };
        return _ordemCompraRepository.Update(id,updateOrdemCompra);
    }

    public OrdemCompra Comprar (int id)
    {
       var ordemDeCompra = _ordemCompraRepository.GetByPk(id);

       var updateOrdemCompra = new UpdateOrdemCompraDto
       {
          IdProduto = ordemDeCompra.IdProduto,
          Quantidade = ordemDeCompra.Quantidade,
          IdOrdemCompraStatus = (int)EOrdemCompraStatus.Comprado,
          Observacao = ordemDeCompra.Observacao
          
          
       };
       _estoqueMovimentoService.Entrada(new CreateEstoqueMovimentoDto()
        
        {
            IdProduto = ordemDeCompra.IdProduto,
            Valor = ordemDeCompra.Valor,
            Quantidade = ordemDeCompra.Quantidade,
        });
        
        return _ordemCompraRepository.Update(id,updateOrdemCompra);
    }

    
    public OrdemCompra Reprovar(int id ,ReprovarOrdemCompraDto ordemCompraDto)
    {
        var ordemDeCompra = _ordemCompraRepository.GetByPk(id);

        var updateOrdemCompra = new UpdateOrdemCompraDto
        {
           IdProduto = ordemDeCompra.IdProduto,
           Quantidade = ordemDeCompra.Quantidade,
           IdOrdemCompraStatus = (int)EOrdemCompraStatus.Reprovado,
           Observacao = ordemCompraDto.Observacao,
           Valor = ordemDeCompra.Valor
           
        };
        
        return _ordemCompraRepository.Update(id, updateOrdemCompra);
    }
}