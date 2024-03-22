using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {


        private readonly AppDbContext? _context;git

        public ProdutosController(AppDbContext? context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var Produtos = _context.Produtos.Take(10).ToList();
            if (Produtos is null) {

                return NotFound("Produtos não encontrados...");

            }
            return Produtos;

        }
        [HttpGet("{id:int}", Name = "ObterProdutos")]
        public ActionResult<Produto> Get(int id)
        {
            var Produtos = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (Produtos is null)
            {

                return NotFound("1 Produtos não encontrados...");

            } return Produtos;
        }
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto == null)
                return BadRequest("1 Produtos não criado...");

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProdutos",
                new { id = produto.ProdutoId }, produto);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {

            if (id != produto.ProdutoId)
                return BadRequest();
            
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
           var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não localizado...");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);

        } 
       

    }
}
