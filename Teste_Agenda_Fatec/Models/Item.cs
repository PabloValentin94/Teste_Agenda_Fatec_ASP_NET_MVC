using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste_Agenda_Fatec.Models
{

    public class Item
    {

        [Display(Name = "ID")]
        [Column(TypeName = "INT")]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Quantidade { get; set; }

        [Required]
        [Display(Name = "ID da Sala")]
        [Column(TypeName = "INT")]
        public int SalaId { get; set; }

        [Required]
        [Display(Name = "ID do Equipamento")]
        [Column(TypeName = "INT")]
        public int EquipamentoId { get; set; }

        [Display(Name = "Sala")]
        public Sala? Sala { get; set; }

        [Display(Name = "Equipamento")]
        public Equipamento? Equipamento { get; set; }

    }

}