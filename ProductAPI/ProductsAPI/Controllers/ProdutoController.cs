using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.Context;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsAPI.Controllers
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
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> PostProduto(TdbProduto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        //// GET: api/<ValuesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        // PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
