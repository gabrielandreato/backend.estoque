using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;
[ApiController]
[Route("api/[controller]")]

public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidoController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreatePedidoDto pedido)
    {
        try
        {
            return Ok(_pedidoService.Create(pedido));
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
            var ByPk = _pedidoService.GetByPk(id);
            return Ok(ByPk);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdatePedidoDto pedidoDto)
    {
        try
        {
            return Ok(_pedidoService.Update(id, pedidoDto));
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        try
        {
            return Ok(_pedidoService.Remove(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetList(string? ids,
        string observacao, int idPedidoStatus, int page = 0, int pageSize = 0)
    {
        try
        {
            return Ok(_pedidoService.GetList(ids, observacao, idPedidoStatus, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    
    
    
}