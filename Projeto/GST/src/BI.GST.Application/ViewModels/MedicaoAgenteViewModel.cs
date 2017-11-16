using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class MedicaoAgenteViewModel
    {
        public int MedicaoAgenteId { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Prencher campo Medição")]
        [DisplayName("Medição")]
        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        public string Medicao { get; set; }

        [DisplayName("Item Demonstra Ambientais")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        public string ItemDemonstraAmbientais { get; set; }

        public bool Delete { get; set; }
    }
}
