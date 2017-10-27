using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BI.GST.Application.ViewModels
{
    public class CIPAEmpresaFuncionarioViewModel
    {
        public int CIPAEmpresaFuncionarioId { get; set; }

        public int CipaEmpresaId { get; set; }

        public virtual CIPAEmpresaViewModel CipaEmpresa { get; set; }

        [Required(ErrorMessage = "Prencher campo Funcionario")]
        [DisplayName("Funcionário")]
        public int FuncionarioId { get; set; }

        public virtual FuncionarioViewModel Funcionario { get; set; }

        [DisplayName("Efetivo")]
        public bool Efetivo { get; set; }

        [DisplayName("Reeleito")]
        public bool Reeleito { get; set; }

        [DisplayName("Ativo")]
        public bool Delete { get; set; }
    }
}
