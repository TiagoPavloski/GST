using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class PPRA
  {
    public int PPRAId { get; set; }

    public int Versao { get; set; }

    public string DataGeracaoPPRA { get; set; }

    public virtual Empresa EmpresaCliente { get; set; }

    public virtual Empresa EmpresaContratante { get; set; }

    public virtual Empresa EmpresaPrestadora { get; set; }

    public string DataEmissao { get; set; }

    public virtual Funcionario ResponsavelTecnico { get; set; }

    public virtual Funcionario ResponsavelMedico { get; set; }

    public virtual Funcionario ResponsavelAmbiental { get; set; }

    public virtual ICollection<AgentePPRA> AgentesAmbientais  { get; set; }

    public string TabelaCIPA { get; set; }

    public bool CIPA { get; set; }

    public string CIPAEfeitos { get; set; }

    public string CIPASuplentes { get; set; }

    public string TabelaSESMT { get; set; }

    public bool SESMT { get; set; }

    public string SESMTEleitos { get; set; }

    public string SESMTSuplentes { get; set; }

    public virtual EquipamentoRuido EquipamentoRuido { get; set; }

    public int Status { get; set; }

    public virtual ICollection<CronogramaDeAcoes> CronogramasDeAcao { get; set; }

    public virtual ICollection<Anexo> Anexos { get; set; }

    //public virtual ICollection<AlteracoesPPRA> AlteracoesPPRA { get; set; } ??? não tem tabela disso

    public string Diretorio { get; set; }

    public bool Delete { get; set; }
  }
}
