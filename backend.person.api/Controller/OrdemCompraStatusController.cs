using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.person.api.Controller;
   [ApiController]
 [Route("[controller]")]
   
   
public class OrdemCompraStatusController: ControllerBase
{
    private readonly IOrdemCompraStatusService _ordemCompraStatusService;

    public OrdemCompraStatusController(IOrdemCompraStatusService ordemCompraStatusService)
    {
        _ordemCompraStatusService = ordemCompraStatusService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] OrdemCompraStatus ordemCompraStatus)
    {
        try
        {
            return Ok(_ordemCompraStatusService.Create(ordemCompraStatus));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetList([FromQuery] string? ids = null, string? descricao = null,
        int page = 0, int pageSize = 0)
    {
        try
        {

            return Ok(_ordemCompraStatusService.GetList(ids, descricao, page, pageSize));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }




    [HttpPut("{id}")]
    public IActionResult Update([FromRoute]int id ,[FromBody]  OrdemCompraStatus ordemCompraStatus)
    {
        try
        {
            return Ok(_ordemCompraStatusService.Update(id, ordemCompraStatus));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{Id}")]
    public IActionResult Remove ([FromRoute] int id)
    {
        try
        {
            return Ok(_ordemCompraStatusService.Remove(id));
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
            return Ok(_ordemCompraStatusService.GetByPk(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



}