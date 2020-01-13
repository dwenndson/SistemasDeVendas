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
    [Route("/Pedido")]
    public class PedidoController :ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Pedidos>>> ListarPedidos([FromServices] DataContext dataContexto)
        {
            var pedidos = await dataContexto.Pedidos.ToListAsync();
            return Ok(pedidos);
        }
        [HttpGet]
        [Route("/{id:int}")]
        public async Task<ActionResult<Pedidos>> PedidoId([FromServices] DataContext data, int id)
        {
            var pedido = await data.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(pedido);
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Pedidos>> AddPedido([FromServices] DataContext data, [FromBody] Pedidos pedido)
        {
            if (ModelState.IsValid)
            {
                var listaItensDoPedidos = PedidoService.RetornarListaItensDoPedido(data, pedido);
                decimal valototal = 0;
                listaItensDoPedidos.ForEach(item => {
                    valototal += item.Valor;
                });
                pedido.ValorTotal = valototal;
                data.Pedidos.Add(pedido);
                await data.SaveChangesAsync();
                string msg = " Produto adicionado com sucesso";
                return Ok(msg);
            }
            else
                return BadRequest(ModelState);
        }
        [HttpPut]
        [Route("/{id:int}")]
        public async Task<ActionResult<Pedidos>> AlteraProduto([FromServices] DataContext data, [FromBody] Pedidos pedido)
        {
            if (ModelState.IsValid)
            {
                data.Pedidos.Update(pedido);
                await data.SaveChangesAsync();
                return Ok(pedido);
            }
            else
            {
                return BadRequest(pedido);
            }
        }

    }
}
