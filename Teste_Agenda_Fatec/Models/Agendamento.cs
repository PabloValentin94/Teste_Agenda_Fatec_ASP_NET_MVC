using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste_Agenda_Fatec.Models
{

    public class Agendamento
    {

        [Display(Name = "ID")]
        [Column(TypeName = "INT")]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data de Emissão Requisição")]
        [Column(TypeName = "DATE")]
        public DateOnly Data_Requisicao { get; set; } = DateOnly.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

        [Display(Name = "Hora de Emissão Requisição")]
        [Column(TypeName = "TIME")]
        public TimeOnly Hora_Requisicao { get; set; } = TimeOnly.Parse(DateTime.Now.ToString("HH:mm:ss"));

        [Required]
        [Display(Name = "Dia Especificado")]
        [Column(TypeName = "DATE")]
        public DateOnly Data_Utilizacao { get; set; }

        [Required]
        [Column(TypeName = "TIME")]
        public TimeOnly Hora_Inicio_Utilizacao { get; set; }

        [Required]
        [Column(TypeName = "TIME")]
        public TimeOnly Hora_Fim_Utilizacao { get; set; }

        [Display(Name = "Situação")]
        [Column(TypeName = "ENUM(\"Pendente\", \"Aprovado\", \"Negado\")")]
        public string? Situacao { get; set; } = "Pendente";

        [Required]
        [Display(Name = "ID da Sala")]
        [Column(TypeName = "INT")]
        public int SalaId { get; set; }

        [Required]
        [Display(Name = "ID do Requisitor")]
        [Column(TypeName = "INT")]
        public int RequisitorId { get; set; }

        [Required]
        [Display(Name = "ID do Aprovador")]
        [Column(TypeName = "INT")]
        public int AprovadorId { get; set; }

        [Display(Name = "Sala")]
        public Sala? Sala { get; set; }

        [Display(Name = "Requisitor")]
        public Usuario? Requisitor { get; set; }

        [Display(Name = "Aprovador")]
        public Usuario? Aprovador { get; set; }

    }

}