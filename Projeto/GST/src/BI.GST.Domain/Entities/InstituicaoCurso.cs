using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class InstituicaoCurso
    {
        public int InstituicaoCursoId { get; set; }

        public string Nome { get; set; }

        public bool InstituicaoCliente { get; set; }

        public bool Delete { get; set; }
    }
}
