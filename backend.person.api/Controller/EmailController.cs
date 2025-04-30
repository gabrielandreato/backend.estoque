using backend.person.api.Services.Interfaces;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;
[ApiController]
[Route("[controller]")]

public class EmailController:ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public IActionResult Create ([FromBody] Email email)
    {
        try
        {
            return Ok(_emailService.Create(email));
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
            return Ok(_emailService.GetByPk(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Email email)
    {
        try
        {
            return Ok(_emailService.Update(id, email));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete("{id}")]
    public IActionResult Remove ([FromRoute] int id)
    {
        try
        {
            return Ok(_emailService.Remove(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetList([FromQuery] string? ids = null, int? idCliente = null, string? email = null,
        int page = 0, int pageSize = 0)
    {

        try
        {
            return Ok(_emailService.GetList(ids, idCliente, email, page, pageSize));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
        
        
    }
    
        
        
        
        
        
    
    
    
}