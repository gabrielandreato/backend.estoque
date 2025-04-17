using backend.person.api.Services.Interfaces;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;
[ApiController]
[Route("[controller]")]


public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] Cliente cliente)
    {
        try
        {
            return Ok(_clienteService.Create(cliente));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

   [HttpGet("{id}")]
   public IActionResult GetByPk([FromRoute] int id)
    {
        try
        { var byPk = _clienteService.GetByPk(id);
            return Ok(byPk);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
           
        }
        
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Cliente cliente)
    {
        try
        {
            return Ok(_clienteService.Update(id,cliente));
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
            return Ok(_clienteService.Remove(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        
    }

    [HttpGet]
    public IActionResult GetList([FromQuery] int[]? ids = null, string? Nome = null, string? DataNascimento = null,
        string? CPF = null, int page = 0, int pageSize = 0)
    {

        try
        {
            return Ok(_clienteService.GetList(ids, Nome, DataNascimento, CPF, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        
        
        
    }
        
    
    
    


}