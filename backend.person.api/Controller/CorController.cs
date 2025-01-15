using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

  [ApiController]
  [Route("[controller]")]

public class CorController : ControllerBase
{
    private readonly ICorService _corService;

    public CorController(ICorService corService)
    {
        _corService = corService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateCorDto cor)
    {
        try
        {
            return Ok(_corService.Create(cor));
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
            return Ok(_corService.GetByPk(id));
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
            return Ok(_corService.Remove(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateCorDto cor)
    {
        try
        {
            return Ok(_corService.Update(id, cor));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet]
    public IActionResult GetList([FromQuery] string? ids = null,
        string? descricao = null, int page = 0, int pageSize = 0)
    {
        try
        {
            return Ok(_corService.GetList(ids, descricao, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    
}