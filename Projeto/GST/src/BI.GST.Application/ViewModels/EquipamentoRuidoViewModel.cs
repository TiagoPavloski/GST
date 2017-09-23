using System;
using System.Collections.Generic;
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
        public string Nome { get; set; }

        [Required(ErrorMessage = "Prencher campo Marca")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        public string MarcaEquipamento { get; set; }

        [Required(ErrorMessage = "Prencher campo Modelo")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        public string ModeloEquipamento { get; set; }
    }
}
