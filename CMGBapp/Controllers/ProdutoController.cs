using CMGBapp.DataContexto;
using CMGBapp.Models;
using CMGBapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMGBapp.Controllers
{
    [ApiController]
    [Route("/Produto")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produtos>>> ListarProduto([FromServices] DataContext dataContext)
        {
            var produto = await dataContext.Produtos.ToListAsync();
            return Ok(produto);
        }
        [HttpGet]
        [Route("/{id:int}")]
        public async Task<ActionResult<Produtos>> ProdutoId([FromServices] DataContext data, int id)
        {
            var produto = await data.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(produto);
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produtos>> AddProduto([FromServices] DataContext data, [FromBody] Produtos produto)
        {
            if (ModelState.IsValid)
            {
                data.Produtos.Add(produto);
                await data.SaveChangesAsync();
                string msg = " Produto adicionado com sucesso";
                return Ok(produto + msg);
            }
            else
                return BadRequest(ModelState);
        }
        [HttpPut]
        [Route("/{id:int}")]
        public async Task<ActionResult<Produtos>> AlteraProduto([FromServices] DataContext data, [FromBody] Produtos produto)
        {
            var auxProduto = ProdutoService.RetornarProduto(data, produto);
            if (ProdutoService.VerificarCategoriaAssociada(data, auxProduto))
            {
                return BadRequest("Produto associado a um pedido. Não possível alterá-lo");

            }
            else if (ModelState.IsValid)
            {
                data.Produtos.Update(produto);
                await data.SaveChangesAsync();
                return Ok(produto);
            }
            else
            {
                return BadRequest(produto);
            }
        }
        [HttpDelete]
        [Route("/{id:int}")]
        public async Task<ActionResult<Produtos>> DeletarProduto([FromServices] DataContext data, int id)
        {
            
            var produto = await data.Produtos.FindAsync(id);
            if(ModelState.IsValid)
            {
                data.Produtos.Remove(produto);
                await data.SaveChangesAsync();
                return Ok("Produto Removido");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
