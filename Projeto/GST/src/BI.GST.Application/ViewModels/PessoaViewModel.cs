using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BI.GST.Application.ViewModels
{
    public class PessoaViewModel
    {
        [Required(ErrorMessage = "Prencher campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Prencher campo CPF")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Prencher campo RG")]
        [DisplayName("RG")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Prencher Data nascimento")]
        [DisplayName("Data Nascimento")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Prencher campo email")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Email")]
        public string Email { get; set; }

        public virtual ICollection<TelefoneViewModel> Telefones { get; set; }
    }
}
