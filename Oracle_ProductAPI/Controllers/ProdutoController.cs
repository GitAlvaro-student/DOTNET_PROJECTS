using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle_ProductAPI.Data;
using Oracle_ProductAPI.Models;

namespace Oracle_ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appDbContext.TBD_Produtos.Add(produto);
            await _appDbContext.SaveChangesAsync();

            return Created("Produto Adicionado com Sucesso!", produto);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _appDbContext.TBD_Produtos.ToListAsync();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutoById(int id)
        {
            var produto = await _appDbContext.TBD_Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound("Produto Não Encontrado!!");
            }

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] Produto prodAtualizado)
        {
            var produtoId = await _appDbContext.TBD_Produtos.FindAsync(id);

            if (produtoId == null)
            {
                return NotFound("Produto Não Encontrado!!");
            }

            _appDbContext.Entry(produtoId).CurrentValues.SetValues(prodAtualizado);
            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, produtoId);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _appDbContext.TBD_Produtos.FindAsync(id);

            if(produto == null)
            {
                return NotFound("Produto Não Encontrado!!");
            }
            _appDbContext.Remove(produto);
            await _appDbContext.SaveChangesAsync();

            return Ok("Produto Deletado Com Sucesso!!");
        }
    }
}
