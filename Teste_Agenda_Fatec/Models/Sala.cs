using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste_Agenda_Fatec.Models
{

    public class Sala
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
        [Display(Name = "Número")]
        [Column(TypeName = "VARCHAR(5)")]
        [StringLength(255, ErrorMessage = "O número máximo de caracteres permitidos é 5.")]
        public string? Numero { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [Column(TypeName = "VARCHAR(255)")]
        [StringLength(255, ErrorMessage = "O número máximo de caracteres permitidos é 255.")]
        public string? Descricao { get; set; } = "Nenhuma descrição.";

        [Display(Name = "Status Atual")]
        [Column(TypeName = "ENUM(\"Disponível\", \"Em uso\", \"Indisponível\")")]
        public string? Status_Atual { get; set; } = "Disponível";

        [Required]
        [Column(TypeName = "TINYINT(1)")]
        public bool Ativo { get; set; } = true;

        [Required]
        [Display(Name = "ID do Bloco")]
        [Column(TypeName = "INT")]
        public int BlocoId { get; set; }

        [Display(Name = "Bloco")]
        [NotMapped]
        public Bloco? Bloco { get; set; }

    }

}