using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class Anexo
    {
        public int AnexoID { get; set; }

        public string Nome { get; set; }

        public string Local { get; set; }

        public byte[] Imagem { get; set; }

        public bool Delete { get; set; }
    }
}
