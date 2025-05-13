using backend.person.api.Services;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
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

        public IActionResult Create([FromBody] Produto produto)
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
        public IActionResult Update(int id, [FromBody] Produto produto)
        {
            try
            {
                return Ok(_produtoService.Update(id, produto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }



        }

        [HttpGet]
        public IActionResult GetList([FromQuery] string? ids = null, string? descricao = null,
         int page = 0, int pageSize = 0, int? idMarca = null, int? idCateggoria = null , int? idMaterial = null, string? tamanho = null )
        {
            try
            {

                return Ok(_produtoService.GetList(ids,descricao,page,pageSize,idMarca,idCateggoria,idMaterial, tamanho ));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        
        [HttpGet("VwProduto")]
        public IActionResult GetVw([FromQuery] string? ids = null, string? descricao = null,
            int page = 0, int pageSize = 0, int? idMarca = null, int? idCategoria = null , int? idMaterial = null, string? tamanho = null)
        {
            try
            {

                return Ok(_produtoService.GetVw(ids, descricao, page, pageSize, idMarca, idCategoria, idMaterial, tamanho));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        
        
    }
}
