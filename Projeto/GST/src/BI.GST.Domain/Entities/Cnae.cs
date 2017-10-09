using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class Cnae
    {
        public int CnaeId { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public string GrauDeRisco { get; set; }

        public bool Delete { get; set; }

        public int GrupoCipaId { get; set; }

        //public int? EmpresaId { get; set; }
        //[ForeignKey("EmpresaId")]
        //public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }

        public virtual GrupoCipa GrupoCipa  { get; set; }
    }
}
