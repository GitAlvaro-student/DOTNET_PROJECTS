using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteProdutos.Context;
using TesteProdutos.Models;

namespace TesteProdutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduto(TdbProduto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            produto = TrownAwayId(produto);

            _appDbContext.TdbProdutos.Add(produto);
            await _appDbContext.SaveChangesAsync();

            return Created("Produto Adicionado com Sucesso!", produto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            var produto = await _appDbContext.TdbProdutos.FindAsync(id);

            if (produto == null)
            {
                return NotFound("Produto Não Encontrado!!");
            }

            return Ok(produto);
        }

        private TdbProduto TrownAwayId(TdbProduto produto)
        {
            var withoutId = new TdbProduto
            {
                NomeProduto = produto.NomeProduto,
                Categoria = produto.Categoria,
                Preco = produto.Preco,
                LojaVendedora = produto.LojaVendedora,
                MarcaProduto = produto.MarcaProduto,
                DataLancamento = produto.DataLancamento,
                QuantidadeEstoque = produto.QuantidadeEstoque
            };

            return withoutId;
        }
    }
}
