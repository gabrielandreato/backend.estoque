using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

[ApiController]
[Route("[controller]")]

public class EstoqueEventoController : ControllerBase
{
    private readonly IEstoqueEventoService _estoqueEventoService;


    public EstoqueEventoController(IEstoqueEventoService estoqueEvento)
    {
        _estoqueEventoService = estoqueEvento;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateEstoqueEventoDto estoqueevento)
    {
        try
        {
            return Ok(_estoqueEventoService.Create(estoqueevento));
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
       
    }

    [HttpGet("{id}")]
    public IActionResult GetByPk(int id)
    {
        try
        {
            return Ok(_estoqueEventoService.GetByPk(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] EstoqueEvento estoqueEvento)
    {
        try
        {
            return Ok(_estoqueEventoService.Update(id, estoqueEvento));
        }
        catch(Exception e)
        {
           return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            return Ok(_estoqueEventoService.Delete(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetList([FromQuery] string? ids, string descricao, int page = 0, int pageSize = 0)
    {
        try
        {
            return Ok(_estoqueEventoService.GetList(ids, descricao, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("VwRelatorioEstoque")]
    public IActionResult GetVwRelatorioEstoque([FromQuery]string? idsProdutos)
    {
        try
        {
            return Ok(_estoqueEventoService.GetVwRelatorioEstoque(idsProdutos));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    
}