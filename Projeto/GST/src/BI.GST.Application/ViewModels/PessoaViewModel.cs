using System.Collections.Generic;
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

        [DisplayName("CPF")]
        public string CPF { get; set; }

        [DisplayName("RG")]
        public string RG { get; set; }

        [DisplayName("Data Nascimento")]
        public string DataNascimento { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Email")]
        public string Email { get; set; }

        public virtual ICollection<TelefoneViewModel> Telefones { get; set; }

    }
}
