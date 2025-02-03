using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

[ApiController]
[Route("[controller]")]

public class PedidoItensController : ControllerBase
{
    private readonly IPedidoItensService _pedidoItensService;

    public PedidoItensController(IPedidoItensService pedidoItensService)
    {
        _pedidoItensService = pedidoItensService;
    }


    [HttpPost]
    public IActionResult Create([FromBody] CreatePedidoItensDto pedidoItensDto)
    {
        try
        {
            return Ok(_pedidoItensService.Create(pedidoItensDto));
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
            var byPk = _pedidoItensService.GetByPk(id);
            return Ok(byPk);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdatePedidoItensDto pedidoItensDto)
    {
        try
        {
            return Ok(_pedidoItensService.Update(id, pedidoItensDto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetList([FromQuery] string? ids, int idPedido, int idProduto,
        int quantidade, int page = 0, int pageSize = 0)
    {
        try
        {
            return Ok(_pedidoItensService.GetList(ids, idPedido, idProduto, quantidade,page,pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
     
    
    
    
    
}