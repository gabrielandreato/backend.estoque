using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

  [ApiController]
  [Route("[controller]")]

public class CorController( ICorService corService) : ControllerBase
{
    
    
    [HttpPost]
    public IActionResult Create([FromBody] Cor cor)
    {
        try
        {
            return Ok(corService.Create(cor));
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
            return Ok(corService.GetByPk(id));
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
            return Ok(corService.Remove(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Cor cor)
    {
        try
        {
            return Ok(corService.Update(id, cor));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet]
    public IActionResult GetList([FromQuery] int[]? ids = null,
        string? descricao = null, int page = 0, int pageSize = 0)
    {
        try
        {
            return Ok(corService.GetList(ids, descricao, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
     
    
    
    
    
}