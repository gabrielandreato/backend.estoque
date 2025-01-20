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
   
    
    
}