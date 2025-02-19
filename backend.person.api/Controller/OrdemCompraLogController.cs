using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

[ApiController]
[Route("[controller]")]

public class OrdemCompraLogController : ControllerBase
{
    private readonly IOrdemCompraLogSerivce _ordemCompraLogService;
    public OrdemCompraLogController(IOrdemCompraLogSerivce ordemCompraService)
    {
        _ordemCompraLogService = ordemCompraService;
    }


    [HttpPost]
    public IActionResult Create([FromBody] OrdemCompraLog ordemCompraLog)
    {
        try
        {
            return Ok(_ordemCompraLogService.Create(ordemCompraLog));
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
            var ByPk  = _ordemCompraLogService.GetByPk(id);
            return Ok(ByPk );
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id ,[FromBody] OrdemCompraLog ordemCompraLog)
    {
        try
        {
            return Ok(_ordemCompraLogService.Update(id,ordemCompraLog));
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
            return Ok(_ordemCompraLogService.Remove(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetList([FromQuery]int[]? ids, int idOrdemDeCompra,
        int idOrdemCompraStatus, int page = 0, int pageSize = 0)
    {
        try
        {
            return Ok(_ordemCompraLogService.GetList(ids, idOrdemDeCompra, idOrdemCompraStatus,page,pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}