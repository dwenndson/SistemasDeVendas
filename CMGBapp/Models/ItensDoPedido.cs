using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMGBapp.Models
{
    public class ItensDoPedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Pedidos")]
        public int PedidoID { get; set; }
        public virtual Pedidos Pedidos { get; set; }
        [Required]
        [ForeignKey("Produtos")]
        public int ProdutoID { get; set; }
        public virtual Produtos Produtos { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        [Column(TypeName ="decimal(9,2)")]
        public decimal Valor { get; set; }

    }
}
