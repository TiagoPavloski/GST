using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class SESMTEmpresaFuncionarioViewModel
    {
        public int SESMTEmpresaFuncionarioId { get; set; }

        public int SESMTEmpresaId { get; set; }

        public virtual SESMTEmpresa SESMTEmpresa { get; set; }

        [Required(ErrorMessage = "Prencher campo Funcionario")]
        [DisplayName("Funcionário")]
        public int FuncionarioId { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        [DisplayName("Efetivo")]
        public bool Efetivo { get; set; }

        [DisplayName("Reeleito")]
        public bool Reeleito { get; set; }

        [DisplayName("Ativo")]
        public bool Delete { get; set; }

    }
}
