using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BI.GST.Application.ViewModels
{
    public class FinanceiroViewModel
    {
        public int FinanceiroId { get; set; }

        [Required(ErrorMessage = "Prencher campo Título")]
        [MaxLength(50, ErrorMessage = "Máximo de 50")]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Prencher Operação do título")]
        [DisplayName("Operação")]
        public int Operacao { get; set; }

        // [Required(ErrorMessage = "Prencher Data do título")]
        [DisplayName("Data da Operação")]
        public string DataOperacao { get; set; }

        //validar para preencher o valor maior que zero
        [Required(ErrorMessage = "Prencher o Valor do título")]
        [DisplayName("Valor")]
        public double Valor { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Instituição")]
        public string Instituicao { get; set; }

        public string OperacaoStatus { get; set; }

        public string Status { get; set; }

        public string StatusNome { get; set; }

        [ScaffoldColumn(false)]
        public bool Delete { get; set; }
    }
}
