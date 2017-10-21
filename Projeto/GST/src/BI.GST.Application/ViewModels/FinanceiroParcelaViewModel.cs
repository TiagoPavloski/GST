using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BI.GST.Application.ViewModels
{
    public class FinanceiroParcelaViewModel
    {
        public int FinanceiroParcelaId { get; set; }

        [Required(ErrorMessage = "Prencher o Número da parcela")]
        public int Parcela { get; set; }

        [Required(ErrorMessage = "Prencher o Valor da parcela")]
        [DisplayName("Valor da Parcela")]
        public double ValorParcela { get; set; }

        [Required(ErrorMessage = "Prencher a Data de vencimento da parcela")]
        [DisplayName("Data Vencimento")]
        public string DataVencimento { get; set; }

        [DisplayName("Data Quitação")]
        public string DataQuitacao { get; set; }

        public int FinanceiroId { get; set; }

        public virtual FinanceiroViewModel Financeiro { get; set; }

        public bool Pago { get; set; }

        public string StatusNome { get; set; }

        public bool Delete { get; set; }
    }
}
