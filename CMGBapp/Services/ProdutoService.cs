using CMGBapp.DataContexto;
using CMGBapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CMGBapp.Services
{
    public static class ProdutoService 
    {
        //Serviço para verficicar se categoria está associada
       public static bool VerificarCategoriaAssociada([FromServices] DataContext data, Produtos produto)
        {
            var isProdutoAssociado = data.ItensDoPedidos.FirstOrDefault(item => item.ProdutoID == produto.Id);
            if(isProdutoAssociado != null)
            {
                return true;
            }
            return false;
        }
        //Retorna um Produto pelo pelo Id se estiver também na tabela de ItensDoPedido
        public static Produtos RetornarProduto([FromServices] DataContext data, ItensDoPedido itensDoPedido)
        {
            var prod = data.Produtos.FirstOrDefault(item => item.Id == itensDoPedido.ProdutoID);
            return prod;
        }

        public static Produtos RetornarProduto([FromServices] DataContext data, Produtos produto)
        {
            var prod = data.Produtos.FirstOrDefault(item => item.Id == produto.Id);
            return prod;
        }
    }
}
