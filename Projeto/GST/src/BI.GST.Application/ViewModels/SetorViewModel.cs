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
    public class SetorViewModel
    {
        public SetorViewModel()
        {
            AgenteQuimicos = new List<AgenteQuimico>();
            AgenteFisicos = new List<AgenteFisico>();
            AgenteAcidentes = new List<AgenteAcidente>();
            AgenteErgonomicos = new List<AgenteErgonomico>();
            AgenteBiologicos = new List<AgenteBiologico>();

        }

        public int SetorId { get; set; }

        [Required]
        [DisplayName("Nome do Setor")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Prencher campo Tipo Setor")]
        public int TipoSetorId { get; set; }

        [ForeignKey("TipoSetorId")]
        public virtual TipoSetorViewModel TipoSetor { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        public string Descricao { get; set; }

        public virtual List<AgenteQuimico> AgenteQuimicos { get; set; }

        public virtual List<AgenteFisico> AgenteFisicos { get; set; }

        public virtual List<AgenteAcidente> AgenteAcidentes { get; set; }

        public virtual List<AgenteErgonomico> AgenteErgonomicos { get; set; }

        public virtual List<AgenteBiologico> AgenteBiologicos { get; set; }

        public bool Delete { get; set; }

		//public int EmpresaId { get; set; }
		//[ForeignKey("EmpresaId")]
		//public virtual EmpresaViewModel Empresa { get; set; }

		public virtual List<EmpresaViewModel> Empresas { get; set; }

	}
}
