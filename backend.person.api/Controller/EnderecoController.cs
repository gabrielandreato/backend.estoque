using backend.person.api.Services.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Request;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;

[ApiController]
[Route("[controller]")]

public class EnderecoController: ControllerBase
{
    private readonly IEnderecoService _enderecoService;

    public EnderecoController(IEnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] Endereco endereco)
    {
        try
        {
            var resultado = _enderecoService.Create(endereco);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetByPk([FromRoute] int id)
    {
        try
        {
            return Ok(_enderecoService.GetByPk(id));
        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Endereco endereco)
    {
        try
        {
            return Ok(_enderecoService.Update(id, endereco));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Remove([FromRoute]int id)
    {
        try
        {
            return Ok(_enderecoService.Remove(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("PorCliente/{idCliente}")]
    public IActionResult RemoveByCustomer([FromRoute] int idCliente)
    {
        try
        {
            return Ok(_enderecoService.RemoveByCustomer(idCliente));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetList([FromQuery] GetEnderecoRequest getEnderecoRequest)
    {
        try
        {
            var resultado = _enderecoService.GetList(getEnderecoRequest);
            return Ok(resultado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    
    
    
    
    
}