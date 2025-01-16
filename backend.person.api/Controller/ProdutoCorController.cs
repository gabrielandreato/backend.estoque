using System.Linq.Expressions;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

[ApiController]
[Route("[controller]")]

public class ProdutoCorController : ControllerBase
{
    private readonly IProdutoCorService _produtocorService;

    public ProdutoCorController(IProdutoCorService produtocorService)
    {
        _produtocorService = produtocorService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProdutoCorDto produtoCor)
    {
        try
        {
            return Ok(_produtocorService.Create(produtoCor));
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
            var byPk = _produtocorService.GetByPk(id);
            return Ok(byPk);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateProdutoCorDto produtoCor)
    {
        try
        {
            return Ok(_produtocorService.Update(id, produtoCor));
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
            return Ok(_produtocorService.Delete(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetList([FromQuery] string? ids ,int? idProduto, int? idCor,
        int page = 0, int pageSize = 0)
    {
        try
        {

            return Ok(_produtocorService.GetList(ids,idProduto,idCor,page,pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    
    
    
}   
