using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class AgenteFisico
    {
        public int AgenteFisicoId { get; set; }

        public string Nome { get; set; }

        public string LimiteTolerancia { get; set; }

        public string NivelAcao { get; set; }

        public string Frequencia { get; set; }

        public string TempoExposicao { get; set; }
        
        public string Tecnica { get; set; }

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

        public virtual ICollection<MedicaoAgente> MedicoesAgente { get; set; }

        public virtual ICollection<MeioPropagacao> MeiosPropagacao { get; set; }

        public virtual ICollection<Setor> Setores { get; set; }

        public virtual ClassificacaoEfeito ClassificacaoEfeito { get; set; }
    }
}
