using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMGBapp.Models
{ 
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Necessário Identificador")]
        [RegularExpression(@"[P]\_[A-Z][0-9][0-9][0-9]\_[C]")]
        [MaxLength(255)]
        public string Identificador { get; set; }
        [MaxLength(1000, ErrorMessage = "Maxímo 1000 caracteres")]
        public string Descricao { get; set; }
        [Required]
        [Column(TypeName = "decimal(21,2)")]
        public decimal ValorTotal { get; set; }
        

    }
}
