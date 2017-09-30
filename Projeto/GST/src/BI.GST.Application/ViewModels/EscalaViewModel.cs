using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BI.GST.Application.ViewModels
{
  public class EscalaViewModel
  {
    public int EscalaId { get; set; }

    [Required(ErrorMessage = "Prencher o nome da escala")]
    [Display(Prompt = "5x2")]
    [MaxLength(25, ErrorMessage = "Máximo de 25 caracteres")]
    [DisplayName("Escala")]
    public string Nome { get; set; }
    
    [DisplayName("Intervalo")]
    [Display(Prompt = "1h")]
    [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres")]
    public string HoraAlmoco { get; set; }

    [ScaffoldColumn(false)]
    public bool Delete { get; set; }
  }
}
