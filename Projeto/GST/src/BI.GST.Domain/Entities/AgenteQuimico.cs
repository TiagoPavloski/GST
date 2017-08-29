using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class AgenteQuimico
  {
    public int AgenteQuimicoId { get; set; }

    public string Nome { get; set; }

    public string LimiteTolerancia { get; set; }

    public virtual ICollection<MeioPropagacao> MeiosPropagacao { get; set; }

    public string Frequencia { get; set; }

    public virtual ClassificacaoEfeito ClassificacaoEfeito { get; set; }

    public string TempoExposicao { get; set; }

    public virtual ICollection<MedicaoAgente> MedicoesAgente { get; set; }

    public string Tecnica { get; set; }

    public string Metodo { get; set; }

    public string Fonte { get; set; }

    public string EPI { get; set; }

    public string EPC { get; set; }

    public string Caracteristicas { get; set; }

    public string Orientacao { get; set; }

    public string MedidasPropostas { get; set; }

    public string MedidasExistentes { get; set; }

    public string AnaliseQualitativa { get; set; }

    public string EfeitosPotenciais { get; set; }

    public string Fundamentacao { get; set; }

    public string Observacao { get; set; }

    public bool Delete { get; set; }
  }
}
