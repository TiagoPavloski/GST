using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class FinanceiroViewModel
    {
        [Required(ErrorMessage = "Prencher campo Título")]
        [MaxLength(50, ErrorMessage = "Máximo de 50")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Prencher Operação do título")]
        [MaxLength(1, ErrorMessage = "Máximo de 1")]
        public int Operacao { get; set; }

        [Required(ErrorMessage = "Prencher Data do título")]
        public string DataOperacao { get; set; }

        //validar para preencher o numero de parcelas
        [Required(ErrorMessage = "Prencher o Número de parcelas do título")]
        public int NumeroParcelas { get; set; }

        [Required(ErrorMessage = "Preencher a Data de Vencimento do título")]
        public string DataVencimento { get; set; }

        //validar para preencher o valor maior que zero
        [Required(ErrorMessage = "Prencher o Valor do título")]
        public double Valor { get; set; }

        [ScaffoldColumn(false)]
        public bool Delete { get; set; }
    }
}
