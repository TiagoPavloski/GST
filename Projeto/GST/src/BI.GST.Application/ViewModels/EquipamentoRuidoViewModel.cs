using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class EquipamentoRuidoViewModel
    {
        public int EquipamentoRuidoId { get; set; }

        [Required(ErrorMessage = "Prencher campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Prencher campo Marca")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Marca Equipamento")]
        public string MarcaEquipamento { get; set; }

        [Required(ErrorMessage = "Prencher campo Modelo")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Modelo Equipamento")]
        public string ModeloEquipamento { get; set; }

        [DisplayName("Comepensação")]
        public string Compensacao { get; set; }

        [DisplayName("Tempo Resposta")]
        public string Resposta { get; set; }
    }
}
