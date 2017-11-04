using BI.GST.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BI.GST.Application.ViewModels
{
    public class CronogramaDeAcoesViewModel
    {
        public int CronogramaDeAcoesId { get; set; }

        [Required]
        [DisplayName("PPRA")]
        public int PPRAId { get; set; }

        [Required(ErrorMessage = "Prencher campo Atividade")]
        [MaxLength(500, ErrorMessage = "Máximo de 500")]
        [DisplayName("Atividade")]
        public string Atividade { get; set; }

        [DisplayName("Data")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Prencher campo Prioridade")]
        public string Prioridade { get; set; }

        public virtual PPRA PPRA { get; set; }
    }
}
