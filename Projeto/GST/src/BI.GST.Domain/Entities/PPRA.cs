﻿using System;
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
            AgentesPPRA = new List<AgentePPRA>();
            CronogramasDeAcao = new List<CronogramaDeAcoes>();
            Anexos            = new List<Anexo>();
        }

        public int PPRAId { get; set; }

        public int Versao { get; set; }

        public string DataGeracaoPPRA { get; set; }

        public string DataValidadePPRA { get; set; }

        public int EmpresaClienteId { get; set; }

        public int EmpresaLocalId { get; set; }

        public int UsuarioId { get; set; }

        public string DataEmissao { get; set; }

        public int ResponsavelTecnicoId { get; set; }

        public int ResponsavelMedicoId { get; set; }

        public int ResponsavelAmbientalId { get; set; }

        public bool CIPA { get; set; }

        public int CIPAEmpresaId { get; set; }

        public int SESMTEmpresaId { get; set; }

        public bool SESMT { get; set; }

        public int EquipamentoRuidoId { get; set; }

        public int Status { get; set; } 

        public bool Delete { get; set; }

        //public virtual ICollection<AlteracoesPPRA> AlteracoesPPRA { get; set; } ??? não tem tabela disso

        public virtual ICollection<AgentePPRA> AgentesPPRA { get; set; }
        public virtual ICollection<CronogramaDeAcoes> CronogramasDeAcao { get; set; }
        public virtual ICollection<Anexo> Anexos { get; set; }
        public virtual Colaborador ResponsavelTecnico { get; set; }
        public virtual Colaborador ResponsavelMedico { get; set; }
        public virtual Colaborador ResponsavelAmbiental { get; set; }
        public virtual EquipamentoRuido EquipamentoRuido { get; set; }
        public virtual Empresa EmpresaCliente { get; set; }
        public virtual Empresa EmpresaLocal { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual CIPAEmpresa CipaEmpresa { get; set; }
        public virtual SESMTEmpresa SESMTEmpresa { get; set; }
    }
}
