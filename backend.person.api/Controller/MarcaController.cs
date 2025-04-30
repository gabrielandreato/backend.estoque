using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

[ApiController]
[Route("[controller]")]
public class MarcaController : ControllerBase
{
    private readonly IMarcaService _marcaService;

    public MarcaController(IMarcaService marcaService)
    {
        _marcaService = marcaService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] Marca marca)
    {
        try
        {
            return Ok(_marcaService.Create(marca));
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
            var byPk = _marcaService.GetByPk(id);
            return Ok(byPk);
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
            return Ok(_marcaService.Remove(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Marca marca)
    {
        try
        {
            return Ok(_marcaService.Update(id, marca));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetList([FromQuery] string? ids = null, string? descricao = null,
        int page = 0, int pageSize = 0)
    {
        try
        {

            return Ok(_marcaService.GetList(ids, descricao, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }


    }
}