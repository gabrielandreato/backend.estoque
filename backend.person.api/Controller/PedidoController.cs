using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
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
    public IActionResult Create([FromBody] Pedido pedido)
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

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Pedido pedido)
    {
        try
        {
            return Ok(_pedidoService.Update(id, pedido));
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
        string? observacao, int? idPedidoStatus, int? idCliente,decimal? precoBruto, string? formaDePagamento,decimal? desconto,decimal? taxas, int page = 0, int pageSize = 0)
    {
        try
        {
            return Ok(_pedidoService.GetList(ids, observacao, idPedidoStatus,idCliente,precoBruto,formaDePagamento,desconto,taxas,page,pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    [HttpPost("PedidoComItens")]
    public IActionResult PedidoComItens([FromBody] CreatePedidoComItensDto pedidoComItensDto)
    {
        try
        {
            return Ok(_pedidoService.PedidoComItens(pedidoComItensDto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("Faturado/({id})")]
    public IActionResult Faturado ([FromRoute]int id)
    {
        try
        {
            return Ok(_pedidoService.Faturar(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("Cancelado/({id})")]
    public IActionResult Cancelado([FromRoute]int id)
    {
        
        try
        {
            return Ok(_pedidoService.Cancelado(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}