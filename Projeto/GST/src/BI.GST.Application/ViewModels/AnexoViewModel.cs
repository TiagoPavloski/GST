using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class AnexoViewModel
    {
        public int AnexoID { get; set; }

        [Required(ErrorMessage = "Prencher campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        public string Local { get; set; }

        [DisplayName("Anexo")]
        public byte[] Imagem { get; set; }

        public int PPRAId { get; set; }
    }
}
