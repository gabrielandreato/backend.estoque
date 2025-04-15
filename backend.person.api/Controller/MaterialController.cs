using backend.person.api.Services.Interfaces;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;
[ApiController]
[Route("[controller]")]
public class MaterialController:ControllerBase
{
    private readonly IMaterialService _materialService;

    public MaterialController(IMaterialService materialService)
    {
        _materialService = materialService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Material material)
    {

        try
        {
            return Ok(_materialService.Create(material));
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
        {
            var byPk = _materialService.GetByPk(id);
            return Ok(byPk);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Material material)
    {
        try
        {
            return Ok(_materialService.Update(id, material));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Remove([FromRoute] int id)
    {
        try
        {
            return Ok(_materialService.Remove(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
        
    [HttpGet]
    public IActionResult GetList(int[]? ids,
        string Materiais, int page = 0, int pageSize = 0)
    {
        try
        {
            return Ok(_materialService.GetList(ids,Materiais,page,pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
}