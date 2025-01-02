using backend.person.api.Services;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace backend.person.api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]

        public IActionResult Create([FromBody] CreateProdutoDto produto)
        {
            try
            {
                return Ok(_produtoService.Create(produto));
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
                var byPk = _produtoService.GetByPk(id);
                return Ok(byPk);
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
                return Ok(_produtoService.Remove(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProdutoDto produtoDto)
        {
            try
            {
                return Ok(_produtoService.Update(id, produtoDto));
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

                return Ok(_produtoService.GetList(ids,  descricao, page, pageSize));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
