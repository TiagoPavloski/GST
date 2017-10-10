using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class GrupoCipaViewModel
    {
        public GrupoCipaViewModel()
        {
            ListaCnae = new List<CnaeViewModel>();
        }

        public int GrupoCipaId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public virtual List<CnaeViewModel> ListaCnae { get; set; }
    }
}
