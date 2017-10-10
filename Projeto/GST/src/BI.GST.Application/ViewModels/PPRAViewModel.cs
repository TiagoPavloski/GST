using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
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
            AgentesAmbientais = new List<AgentePPRAViewModel>();
            CronogramasDeAcao = new List<CronogramaDeAcoesViewModel>();
            Anexos = new List<AnexoViewModel>();

        }

        public int PPRAId { get; set; }

        public int Versao { get; set; }

        public string DataGeracaoPPRA { get; set; }

        public int EmpresaClienteId { get; set; }

        public int EmpresaContratanteId { get; set; }

        public int EmpresaPrestadoraId { get; set; }

        public string DataEmissao { get; set; }

        public int ResponsavelTecnicoId { get; set; }

        public int ResponsavelMedicoId { get; set; }

        public int ResponsavelAmbientalId { get; set; }

        public bool CIPA { get; set; }

        public int CIPAEleitosId { get; set; }

        public int CIPASuplentesId { get; set; }

        public bool SESMT { get; set; }

        public int SESMTEleitosId { get; set; }

        public int SESMTSuplentesId { get; set; }

        public int EquipamentoRuidoId { get; set; }

        public int Status { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("CIPAEleitosId")]
        public virtual List<FuncionarioEmpresa> CIPAEleitos { get; set; }
        [ForeignKey("CIPASuplentesId")]
        public virtual List<FuncionarioEmpresa> CIPASuplentes { get; set; }
        [ForeignKey("SESMTEleitosId")]
        public virtual List<FuncionarioEmpresa> SESMTEleitos { get; set; }
        [ForeignKey("SESMTSuplentesId")]
        public virtual List<FuncionarioEmpresa> SESMTSuplentes { get; set; }

        
        public virtual List<AgentePPRAViewModel> AgentesAmbientais { get; set; }
        public virtual List<CronogramaDeAcoesViewModel> CronogramasDeAcao { get; set; }
        public virtual List<AnexoViewModel> Anexos { get; set; }
      //  public virtual ColaboradorViewModel ResponsavelTecnico { get; set; }
      //  public virtual ColaboradorViewModel ResponsavelMedico { get; set; }
      //  public virtual ColaboradorViewModel ResponsavelAmbiental { get; set; }
        public virtual EquipamentoRuidoViewModel EquipamentoRuido { get; set; }
        public virtual EmpresaViewModel EmpresaCliente { get; set; }
        public virtual EmpresaViewModel EmpresaContratante { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
    }
}
