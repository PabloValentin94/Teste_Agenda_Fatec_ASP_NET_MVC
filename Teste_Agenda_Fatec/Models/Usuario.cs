using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste_Agenda_Fatec.Models
{

    public class Usuario
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
        [Column(TypeName = "VARCHAR(255)")]
        [StringLength(255, ErrorMessage = "O número máximo de caracteres permitidos é 255.")]
        public string? Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(20, ErrorMessage = "O número máximo de caracteres permitidos é 20.")]
        public string? Senha { get; set; }

        [Required]
        [Column(TypeName = "TINYINT(1)")]
        public bool Administrador { get; set; } = false;

        [Required]
        [Column(TypeName = "TINYINT(1)")]
        public bool Ativo { get; set; } = true;

        [Required]
        [Display(Name = "ID do Cargo")]
        [Column(TypeName = "INT")]
        public int CargoId { get; set; }

        [Display(Name = "Cargo")]
        [NotMapped]
        public Cargo? Cargo { get; set; }

    }

}