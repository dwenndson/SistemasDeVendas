using CMGBapp.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMGBapp.Models
{
    public class Produtos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo Necessário")]
        [MaxLength(255)]
        public string Nome { get; set; }
        [Required]
        public Categoria Categoria { get; set; }

    }
}
