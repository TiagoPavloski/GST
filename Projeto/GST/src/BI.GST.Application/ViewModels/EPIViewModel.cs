using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BI.GST.Application.ViewModels
{
    public class EPIViewModel
    {
       
        public int EPIId { get; set; }

        [DisplayName("EPI")]
        [Required(ErrorMessage = "Prencher o nome do EPI")]
        [MaxLength(35, ErrorMessage = "Máximo de 35 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Prencher campo Status")]
        public int Status { get; set; }

        public string StatusNome { get; set; }

        public bool Delete { get; set; }
    }
}
