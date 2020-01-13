using CMGBapp.DataContexto;
using CMGBapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMGBapp.Services
{
    public static class ItemPedidoService
    {
        //Identificar se o Pedido está associado para validação
        public static bool ItemPedidoAssociadoPedido([FromServices] DataContext data, ItensDoPedido itensDoPedido)
        {
            var istemPedidoAssociadoPedido = data.ItensDoPedidos.FirstOrDefault(item => item.PedidoID == itensDoPedido.PedidoID && item.Id == itensDoPedido.Id);
            if( istemPedidoAssociadoPedido != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //Obter um ItemDoPedido por ID
        public static ItensDoPedido ItemDoPedidoPorId([FromServices] DataContext data, ItensDoPedido itensDoPedido)
        {
            var resultQuery = data.ItensDoPedidos.FirstOrDefault(item => item.Id == itensDoPedido.Id);
            return resultQuery;
        }
    }
}
