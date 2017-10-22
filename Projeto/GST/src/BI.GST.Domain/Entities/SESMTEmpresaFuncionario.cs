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

        public int FuncionarioId { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        public bool Efetivo { get; set; }

        public bool Reeleito { get; set; }

        public bool Delete { get; set; }
    }
}
