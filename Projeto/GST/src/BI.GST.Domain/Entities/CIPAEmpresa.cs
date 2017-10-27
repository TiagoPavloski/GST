using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class CIPAEmpresa
    {
        public CIPAEmpresa()
        {
            CIPAEmpresaFuncionarios = new List<CIPAEmpresaFuncionario>();
        }

        public int CipaEmpresaID { get; set; }

        public int Ano { get; set; }

        public int NumeroFuncionarios { get; set; }

        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }

        public bool Delete { get; set; }

        public int NumeroFuncionariosEfetivos { get; set; }

        public int NumeroFuncionariosSuplentes { get; set; }

        public virtual ICollection<CIPAEmpresaFuncionario> CIPAEmpresaFuncionarios { get; set; }

    }
}
