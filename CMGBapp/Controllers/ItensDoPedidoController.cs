using CMGBapp.DataContexto;
using CMGBapp.Models;
using CMGBapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMGBapp.Controllers
{
    [ApiController]
    [Route("/ItensDoPedido")]
    public class ItensDoPedidoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ItensDoPedido>>> ListarItens([FromServices] DataContext dataContext)
        {
            var itensDoPedido = await dataContext.ItensDoPedidos.ToListAsync();
            return Ok(itensDoPedido);
        }
        [HttpGet]
        [Route("/{id:int}")]
        public async Task<ActionResult<ItensDoPedido>> ItemId([FromServices] DataContext data, int id)
        {
            var itensDoPedido = await data.ItensDoPedidos.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(itensDoPedido);
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ItensDoPedido>> AddItem([FromServices] DataContext data, [FromBody] ItensDoPedido itensDoPedido)
        {
            if (ItemPedidoService.ItemPedidoAssociadoPedido(data, itensDoPedido))
            {
                var itemDoPedidoNovo = ItemPedidoService.ItemDoPedidoPorId(data, itensDoPedido);
                itemDoPedidoNovo.Quantidade += 1;
                return await AlteraItem(data, itemDoPedidoNovo);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    data.ItensDoPedidos.Add(itensDoPedido);
                    await data.SaveChangesAsync();
                    return Ok("Item adicionado com sucesso");
                }
                else
                    return BadRequest(ModelState);
            }
        }
        [HttpPut]
        [Route("/{id:int}")]
        public async Task<ActionResult<ItensDoPedido>> AlteraItem([FromServices] DataContext data, [FromBody] ItensDoPedido itensDoPedido)
        {
             if (ModelState.IsValid)
            {
                
                data.ItensDoPedidos.Update(itensDoPedido);
                await data.SaveChangesAsync();
                return Ok(itensDoPedido);
            }
            else
            {
                return BadRequest(itensDoPedido);
            }
        }
        [HttpDelete]
        [Route("/{id:int}")]
        public async Task<ActionResult<ItensDoPedido>> DeletarProduto([FromServices] DataContext data, int id)
        {

            var produto = await data.ItensDoPedidos.FindAsync(id);
            if (ModelState.IsValid)
            {
                data.ItensDoPedidos.Remove(produto);
                await data.SaveChangesAsync();
                return Ok("Item Removido");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

