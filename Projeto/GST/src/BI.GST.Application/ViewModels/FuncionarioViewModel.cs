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
    public class FuncionarioViewModel : PessoaViewModel
    {

        public int FuncionarioId { get; set; }

        public int Status { get; set; }

        [DisplayName("Status")]
        public string StatusNome { get; set; }

        [DisplayName("PIS")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        public string PIS { get; set; }

        [DisplayName("CLT")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        public string CLT { get; set; }

        [DisplayName("Série")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        public string Serie { get; set; }

        [DisplayName("Admissão")]
        public string Admissao { get; set; }

        [DisplayName("Demissão")]
        public string Demissao { get; set; }

        [DisplayName("Responsável da Empresa?")]
        public bool Responsavel { get; set; }

        [DisplayName("Inicio do turno")]
        public string HoraEntrada { get; set; }

        [DisplayName("Fim do Turno")]
        public string HoraSaida { get; set; }

        public bool Delete { get; set; }

        [DisplayName("Empresa")]
        public int EmpresaId { get; set; }
        public virtual EmpresaViewModel Empresa { get; set; }

        [DisplayName("Função na empresa")]
        public int CBOId { get; set; }
        public virtual CBOViewModel CBO { get; set; }

        [DisplayName("Setor do funcionário")]
        public int SetorId { get; set; }
        public virtual SetorViewModel Setor { get; set; }

        [DisplayName("Tipo de escala do funcionário")]
        public int EscalaId { get; set; }
        public virtual EscalaViewModel Escala { get; set; }


    }
}
