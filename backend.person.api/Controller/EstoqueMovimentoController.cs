using backend.person.api.Services;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

[ApiController]
[Route("[controller]")]


public class EstoqueMovimentoController : ControllerBase
{
    private readonly IEstoqueMovimentoService _estoqueMovimentoService;

    public EstoqueMovimentoController(IEstoqueMovimentoService estoqueMovimento)
    {
        _estoqueMovimentoService = estoqueMovimento;
    }

    [HttpGet]
    public IActionResult GetList([FromQuery]string? ids = null , int? idProduto = null , int? idEstoqueEvento = null ,
        int page = 0, int pageSize = 0)
    {
        try
        {

            return Ok(_estoqueMovimentoService.GetList(ids, idProduto, idEstoqueEvento, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpPost("Entrada")]
    public IActionResult Entrada([FromBody] EstoqueMovimento estoqueMovimento)
    {
        try
        {
            return Ok(_estoqueMovimentoService.Entrada(estoqueMovimento));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("Saida")]
    public IActionResult Saida([FromBody] EstoqueMovimento estoqueMovimento)
    {
        try
        {
            return Ok(_estoqueMovimentoService.Saida(estoqueMovimento));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    
    
}