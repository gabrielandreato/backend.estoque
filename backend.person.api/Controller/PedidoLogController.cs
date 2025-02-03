using backend.person.api.Services.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;
[ApiController]
[Route("[controller]")]

public class PedidoLogController : ControllerBase
{
    private readonly IPedidoLogService _pedidoLogService;

    public PedidoLogController(IPedidoLogService pedidoLogService)
    {
        _pedidoLogService = pedidoLogService;
    }


    [HttpPost]
    public IActionResult Create([FromBody] PedidoLog pedidoLog)
    {
        try
        {
            return Ok(_pedidoLogService.Create(pedidoLog));
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
            return Ok(_pedidoLogService.GetByPk(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPut("{id}")]
    public IActionResult Update([FromRoute]int id ,[FromBody] PedidoLog pedidoLog)
    {
        try
        {
            return Ok(_pedidoLogService.Update(id,pedidoLog));
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
            return Ok(_pedidoLogService.Remove(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet]
    public IActionResult GetList
        ([FromQuery] string? ids, int idPedido, int idStatus, int page = 0, int pageSize=0)
    {
        try
        {
            return Ok(_pedidoLogService.GetList(ids, idPedido, idStatus, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}