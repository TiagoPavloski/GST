using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class SESMTEmpresaFuncionario
    {
        public int SESMTEmpresaFuncionarioId { get; set; }

        public int SESMTEmpresaId { get; set; }

        public virtual SESMTEmpresa SESMTEmpresa { get; set; }

        public int FuncionarioEmpresaId { get; set; }

        public virtual FuncionarioEmpresa FuncionarioEmpresa { get; set; }

        public bool Efetivo { get; set; }

        public bool Reeleito { get; set; }

        public bool Delete { get; set; }
    }
}
