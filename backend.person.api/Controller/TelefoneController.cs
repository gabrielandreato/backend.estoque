using backend.person.api.Services.Interfaces;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

[ApiController]
[Route("[controller]")]

public class TelefoneController : ControllerBase
{
    private readonly ITelefoneService _telefoneService;

    public TelefoneController(ITelefoneService telefoneService)
    {
        _telefoneService = telefoneService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] Telefone telefone)
    {
        try
        {
            return Ok(_telefoneService.Create(telefone));
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetByPk([FromRoute] int id)
    {
        try
        {
            var byPk = _telefoneService.GetByPk(id);
            return Ok(byPk);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Telefone telefone)
    {

        try
        {
            return Ok(_telefoneService.Update(id, telefone));
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
            return Ok(_telefoneService.Remove(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet]
    public IActionResult GetList([FromQuery] int[]? ids = null, string? Telefones = null,
        int? IdCliente = null, int page = 0, int pageSize = 0)
    {
        try
        {
            return Ok(_telefoneService.GetList(ids, Telefones, IdCliente, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    
    
    
}