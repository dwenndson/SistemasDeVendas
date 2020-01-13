using CMGBapp.DataContexto;
using CMGBapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMGBapp.Services
{
    public static class PedidoService
    {
        //Serviço do Pedido para retornar os Produto que estão dentro da tabelas ItensDoPedido
        public static List<ItensDoPedido> RetornarListaItensDoPedido([FromServices] DataContext data, Pedidos pedido)
        {
            var ListaItensDoPedido = data.ItensDoPedidos.Where(item => item.PedidoID == pedido.Id);
            List<ItensDoPedido> itens = new List<ItensDoPedido>(ListaItensDoPedido);
            return itens;
        }
    }
}
