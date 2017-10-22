using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.GST.Application.ViewModels
{
    public class CIPAEmpresaViewModel
    {
        public CIPAEmpresaViewModel()
        {
            CIPAEmpresaFuncionarios = new List<CIPAEmpresaFuncionarioViewModel>();
        }

        public int CipaEmpresaID { get; set; }

        [Required(ErrorMessage = "Prencher Ano")]
        [DisplayName("Ano")]
        public int Ano { get; set; }

        [DisplayName("Número de Funcionários")]
        public int NumeroFuncionarios { get; set; }

        [DisplayName("Funcionários Efetivos")]
        public int NumeroFuncionariosEfetivos { get; set; }

        [DisplayName("Funcionários Suplentes")]
        public int NumeroFuncionariosSuplentes { get; set; }

        [Required(ErrorMessage = "Prencher campo Empresa")]
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public virtual EmpresaViewModel Empresa { get; set; }

        [DisplayName("Ativo")]
        public bool Delete { get; set; }

        

        public virtual List<CIPAEmpresaFuncionarioViewModel> CIPAEmpresaFuncionarios { get; set; }
    }
}
