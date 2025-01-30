using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

[ApiController]
[Route("api/[controller]")]

public class PedidoStatusController : ControllerBase
{
  private readonly IPedidoStatusService _pedidoStatusService;

  public PedidoStatusController(IPedidoStatusService pedidoStatusService)
  {
    _pedidoStatusService = pedidoStatusService;
  }


  [HttpPost]
  public IActionResult Create([FromBody] CreatePedidoStatusDto pedidoStatus)
  {
    try
    {
      return Ok(_pedidoStatusService.Create(pedidoStatus));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public IActionResult GetByPk(int id)
  {
    
      try
      {
        var byPk = _pedidoStatusService.GetByPk(id);
        return Ok(byPk);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
  }


  [HttpPut("{id}")]
  public IActionResult Update([FromRoute]int id, [FromBody]UpdatePedidoStatusDto pedidoStatus)
  {
    try
    {
      return Ok(_pedidoStatusService.Update(id, pedidoStatus));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public IActionResult Remove(int id)
  {
    try
    {
      return Ok(_pedidoStatusService.Remove(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public IActionResult GetList([FromQuery] string? ids,
    string observacao, int page = 0, int pageSize = 0)
  {
    try
    {
      return Ok (_pedidoStatusService.GetList(ids, observacao, page, pageSize));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  
  
}