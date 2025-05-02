using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste_Agenda_Fatec.Models
{

    public class Cargo
    {

        [Display(Name = "ID")]
        [Column(TypeName = "INT")]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        [StringLength(255, ErrorMessage = "O número máximo de caracteres permitidos é 255.")]
        public string? Nome { get; set; }

        [Required]
        [Column(TypeName = "TINYINT(1)")]
        public bool Ativo { get; set; } = true;

    }

}