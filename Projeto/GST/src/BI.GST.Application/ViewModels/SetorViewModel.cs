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
        public int SetorId { get; set; }

        [Required]
        [DisplayName("Setor")]
        public string Nome { get; set; }

        public virtual TipoSetorViewModel TipoSetor { get; set; }

        [Required(ErrorMessage = "Prencher campo Descrição")]
        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Prencher campo Status")]
        public int Status { get; set; }

        public virtual ICollection<AgenteQuimico> AgenteQuimicos { get; set; }

        public virtual ICollection<AgenteFisico> AgenteFisicos { get; set; }

        public virtual ICollection<AgenteAcidente> AgenteAcidentes { get; set; }

        public virtual ICollection<AgenteErgonomico> AgenteErgonomicos { get; set; }

        public virtual ICollection<AgenteBiologico> AgenteBiologicos { get; set; }

        public bool Delete { get; set; }

        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual EmpresaViewModel Empresa { get; set; }
    }
}
