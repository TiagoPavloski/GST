using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class PPRA
    {
        public PPRA()
        {
            AgentesAmbientais = new List<AgentePPRA>();
            CronogramasDeAcao = new List<CronogramaDeAcoes>();
            Anexos            = new List<Anexo>();
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

        public string TabelaCIPA { get; set; }

        public string TabelaSESMT { get; set; }

        public bool SESMT { get; set; }

        public int SESMTEleitosId { get; set; }

        public int SESMTSuplentesId { get; set; }

        public int EquipamentoRuidoId { get; set; }

        public int Status { get; set; } 

        public string Diretorio { get; set; }

        public bool Delete { get; set; }

        //public virtual ICollection<AlteracoesPPRA> AlteracoesPPRA { get; set; } ??? não tem tabela disso
        [ForeignKey("CIPAEleitosId")]
        public virtual ICollection<FuncionarioEmpresa> CIPAEleitos { get; set; }
        [ForeignKey("CIPASuplentesId")]
        public virtual ICollection<FuncionarioEmpresa> CIPASuplentes { get; set; }
        [ForeignKey("SESMTEleitosId")]
        public virtual ICollection<FuncionarioEmpresa> SESMTEleitos { get; set; }
        [ForeignKey("SESMTSuplentesId")]
        public virtual ICollection<FuncionarioEmpresa> SESMTSuplentes { get; set; }
        public virtual ICollection<AgentePPRA> AgentesAmbientais { get; set; }
        public virtual ICollection<CronogramaDeAcoes> CronogramasDeAcao { get; set; }
        public virtual ICollection<Anexo> Anexos { get; set; }
        public virtual Colaborador ResponsavelTecnico { get; set; }
        public virtual Colaborador ResponsavelMedico { get; set; }
        public virtual Colaborador ResponsavelAmbiental { get; set; }
        public virtual EquipamentoRuido EquipamentoRuido { get; set; }
        public virtual Empresa EmpresaCliente { get; set; }
        public virtual Empresa EmpresaContratante { get; set; }
        public virtual Empresa EmpresaPrestadora { get; set; }
    }
}
