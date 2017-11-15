using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class PPRAViewModel
    {
        public PPRAViewModel()
        {
            AgentesPPRA = new List<AgentePPRAViewModel>();
            CronogramasDeAcao = new List<CronogramaDeAcoesViewModel>();
            Anexos = new List<AnexoViewModel>();

        }

        public int PPRAId { get; set; }

        [Required(ErrorMessage = "Prencher campo Versão")]
        [DisplayName("Versão")]
        public int Versao { get; set; }

        [Required(ErrorMessage = "Selecionar Data Geração")]
        [DisplayName("Data Geração PPRA")]
        public string DataGeracaoPPRA { get; set; }

        [Required(ErrorMessage = "Selecionar Data Validade")]
        [DisplayName("Data Validade PPRA")]
        public string DataValidadePPRA { get; set; }

        [Required(ErrorMessage = "Selecionar Empresa Cliente")]
        [DisplayName("Empresa Cliente")]
        public int EmpresaClienteId { get; set; }

        [Required(ErrorMessage = "Selecionar Empresa Local")]
        [DisplayName("Empresa Local")]
        public int EmpresaLocalId { get; set; }

        //public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Prencher Data Emissão")]
        [DisplayName("Data Emissão")]
        public string DataEmissao { get; set; }

        [Required(ErrorMessage = "Selecionar Responsável técnico")]
        [DisplayName("Responsável técnico")]
        public int ResponsavelTecnicoId { get; set; }
         
        [DisplayName("Responsável médico")]
        public int ResponsavelMedicoId { get; set; }

        [DisplayName("Responsável ambiental")]
        public int ResponsavelAmbientalId { get; set; }

        //public int CipaEmpresaId { get; set; }

        //public bool CIPA { get; set; }

        //public bool SESMT { get; set; }

        [DisplayName("Equipamento medição de ruído")]
        public int EquipamentoRuidoId { get; set; }

        public int Status { get; set; }

        public bool Delete { get; set; }

        
        public virtual List<AgentePPRAViewModel> AgentesPPRA { get; set; }
        public virtual List<CronogramaDeAcoesViewModel> CronogramasDeAcao { get; set; }
        public virtual List<AnexoViewModel> Anexos { get; set; }
        public virtual ColaboradorViewModel ResponsavelTecnico { get; set; }
        public virtual ColaboradorViewModel ResponsavelMedico { get; set; }
        public virtual ColaboradorViewModel ResponsavelAmbiental { get; set; }
        public virtual EquipamentoRuidoViewModel EquipamentoRuido { get; set; }
        public virtual EmpresaViewModel EmpresaCliente { get; set; }
        public virtual EmpresaViewModel EmpresaLocal { get; set; }
        //public virtual UsuarioViewModel Usuario { get; set; }
        //public virtual CIPAEmpresaViewModel CipaEmpresa { get; set; }
    }
}
