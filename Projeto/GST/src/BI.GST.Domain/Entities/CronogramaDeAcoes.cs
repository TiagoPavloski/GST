using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class CronogramaDeAcoes
    {
        public int CronogramaDeAcoesId { get; set; }

        public int PPRAId { get; set; }

        public virtual PPRA PPRA { get; set; }

        public string Atividade { get; set; }

        public string Data { get; set; }

        public string Prioridade { get; set; }

        public bool Delete { get; set; }
    }
}
