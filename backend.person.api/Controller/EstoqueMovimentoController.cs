using backend.person.api.Services;
using backend.person.api.Services.Interfaces;
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
    public IActionResult GetList([FromQuery] string? ids, int IdProduto, int IdEstoqueMovimento,
        int page = 0, int pageSize = 0)
    {
        try
        {

            return Ok(_estoqueMovimentoService.GetList(ids, IdProduto, IdEstoqueMovimento, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }



    }
}