using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class FinanceiroParcela
    {
        public int FinanceiroParcelaId { get; set; }

        public int Parcela { get; set; }

        public double  ValorParcela { get; set; }

        public string DataVencimento { get; set; }

        public string DataQuitacao { get; set; }

        public int FinanceiroId { get; set; }

        public virtual Financeiro Financeiro { get; set; }

        public bool Pago { get; set; }

        public bool Delete { get; set; }
    }
}
