using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class Telefone
    {
        public int TelefoneId { get; set; }

        public string Numero { get; set; }

        public bool Delete { get; set; }


        public int EmpresaUtilizadoraId { get; set; }
        [ForeignKey("EmpresaUtilizadoraId")]
        public virtual EmpresaUtilizadora EmpresaUtilizadora { get; set; }

        //public int? EmpresaId { get; set; }
        //[ForeignKey("EmpresaId")]
        //public virtual Empresa Empresa { get; set; }
    }
}
