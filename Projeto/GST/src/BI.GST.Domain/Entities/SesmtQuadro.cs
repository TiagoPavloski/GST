using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class SesmtQuadro
    {
        public int SesmtQuadroId { get; set; }

        public int GrauDeRisco { get; set; }

        public int NumeroEmpregadosInicial { get; set; }

        public int NumeroEmpregadosFinal { get; set; }

        public int QuantidadeTecnicoSeg { get; set; }

        public int QuantidadeEngenheiroSeg { get; set; }

        public int QuantidadeAuxEnfermagem { get; set; }

        public int QuantidadeEnfermeiro { get; set; }

        public int QuantidadeMedico { get; set; }

    }
}
