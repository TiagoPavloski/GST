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
    public class FuncionarioViewModel
    {
        [Required(ErrorMessage = "Prencher campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("CPF")]
        public string CPF { get; set; }

        [DisplayName("RG")]
        public string RG { get; set; }
        
        [DisplayName("Data Nascimento")]
        public string DataNascimento { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("PIS")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        public string PIS { get; set; }

        [DisplayName("CLT")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        public string CLT { get; set; }

        [DisplayName("Série")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        public string Serie { get; set; }

        public int FuncionarioId { get; set; }

        public int Status { get; set; }

        [DisplayName("Status")]
        public string StatusNome { get; set; }

        [DisplayName("Responsável da Empresa?")]
        public bool Responsavel { get; set; }

        [Required(ErrorMessage = "Selecione uma empresa")]
        [DisplayName("Empresa")]
        public int EmpresaId { get; set; }
       
        [DisplayName("Inicio do turno")]
        public string HoraEntrada { get; set; }

        [DisplayName("Fim do Turno")]
        public string HoraSaida { get; set; }

        [DisplayName("Admissão")]
        public string Admissao { get; set; }

        [Required(ErrorMessage = "Selecione uma função")]
        [DisplayName("Função na empresa")]
        public int CBOId { get; set; }

        [Required(ErrorMessage = "Selecione um setor")]
        [DisplayName("Setor do funcionário")]
        public int SetorId { get; set; }

        [Required(ErrorMessage = "Selecione uma escala")]
        [DisplayName("Tipo de escala do funcionário")]
        public int EscalaId { get; set; }

        [DisplayName("Demissão")]
        public string Demissao { get; set; }

        public bool Delete { get; set; }

        public virtual EmpresaViewModel Empresa { get; set; }
        public virtual CBOViewModel CBO { get; set; }
        public virtual SetorViewModel Setor { get; set; }
        public virtual EscalaViewModel Escala { get; set; }
        public virtual List<CursoViewModel> Cursos { get; set; }










    }
}
