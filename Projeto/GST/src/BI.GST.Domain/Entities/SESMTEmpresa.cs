using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class SESMTEmpresa
    {
        public SESMTEmpresa()
        {
            SESMTEmpresaFuncionarios = new List<SESMTEmpresaFuncionario>();
        }

        public int SESMTEmpresaID { get; set; }

        public int Ano { get; set; }

        public int NumeroFuncionarios { get; set; }

        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }

        public bool Delete { get; set; }

        public virtual ICollection<SESMTEmpresaFuncionario> SESMTEmpresaFuncionarios { get; set; }



    }
}
