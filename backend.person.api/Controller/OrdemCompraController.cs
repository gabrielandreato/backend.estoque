using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;
[ApiController]
[Route("[controller]")]
public class OrdemCompraController : ControllerBase
{
    private readonly IOrdemCompraService _ordemCompraService;

    public OrdemCompraController(IOrdemCompraService ordemCompraService)
    {
       _ordemCompraService = ordemCompraService; 
    }

    [HttpPost]
    public IActionResult Create([FromBody] OrdemCompra ordemCompra)
    {
        try
        {
            return Ok(_ordemCompraService.Create(ordemCompra));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetByPk([FromRoute] int id)
    {
        try
        {
            return Ok(_ordemCompraService.GetByPk(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    
    

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] OrdemCompra ordemCompra)
    {
        try
        {
            return Ok(_ordemCompraService.Update(id, ordemCompra));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Remove([FromRoute] int id)
    {
        try
        {
            return Ok(_ordemCompraService.Remove(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    public IActionResult GetList([FromQuery] string? ids ,int? idProduto ,int? idOrdemCompraStatus,  
        int page = 0, int pageSize = 0)
    {
        try
        {

            return Ok(_ordemCompraService.GetList(ids,idProduto,idOrdemCompraStatus,page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("Comprar/{id}")]
    public IActionResult Comprar([FromRoute] int id)
    {
        try
        {
            return Ok(_ordemCompraService.Comprar(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("Aprovar/{id}")]
    public IActionResult Aprovar([FromRoute] int  id )
    {
        try
        {
            return Ok(_ordemCompraService.Aprovar(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
   

    [HttpPut("Reprovar/{id}")]
    public IActionResult Reprovar ([FromRoute] int id, [FromBody] ReprovarOrdemCompraDto ordemCompraDto)
    {
        try
        {
            return Ok(_ordemCompraService.Reprovar(id, ordemCompraDto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

