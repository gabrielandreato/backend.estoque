using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

[ApiController]
[Route("[controller]")]

public class ProdutoCategoriaController : ControllerBase
{
    private readonly IProdutoCategoriaService _produtocategoriaService;

    public ProdutoCategoriaController(IProdutoCategoriaService produtocategoriaService)
    {
        _produtocategoriaService = produtocategoriaService;
    }

    [HttpPost]

    public IActionResult Create([FromBody] ProdutoCategoria produtoCategoria)
    {
        try
        {
            return Ok(_produtocategoriaService.Create(produtoCategoria));
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
            var byPk = _produtocategoriaService.GetByPk(id);
            return Ok(byPk);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            return Ok(_produtocategoriaService.Remove(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] ProdutoCategoria produtoCategoria)
    {
        try
        {

            return Ok(_produtocategoriaService.Update(id, produtoCategoria));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetList([FromQuery] int[]? ids = null, string? descricao = null,
        int page = 0, int pageSize = 0)
    {
        try
        {

            return Ok(_produtocategoriaService.GetList(ids, descricao, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    
    
}
    
    