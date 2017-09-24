using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class TipoSetorViewModel
    {
        public int TipoSetorId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public bool Delete { get; set; }
    }
}
