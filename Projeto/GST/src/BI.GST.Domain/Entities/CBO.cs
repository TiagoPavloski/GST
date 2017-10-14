using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class CBO
    {
        public CBO()
        {
            RiscoCBOs = new List<RiscoCBO>();
            TipoCursos = new List<TipoCurso>();
            TipoExames = new List<TipoExame>();
            TipoVacinas = new List<TipoVacina>();
        }
        public int CBOId { get; set; }

        public string Nome { get; set; }

        public string CodigoCBO { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<RiscoCBO> RiscoCBOs { get; set; }

        public virtual ICollection<TipoCurso> TipoCursos { get; set; }

        public virtual ICollection<TipoExame> TipoExames { get; set; }

        public virtual ICollection<TipoVacina> TipoVacinas { get; set; }

        public bool Delete { get; set; }
    }
}
