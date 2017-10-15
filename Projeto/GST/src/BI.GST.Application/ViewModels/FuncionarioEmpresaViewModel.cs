using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BI.GST.Application.ViewModels
{
	public class FuncionarioEmpresaViewModel
	{
		public int FuncionarioEmpresaId { get; set; }

		public int EmpresaId { get; set; }

		public virtual EmpresaViewModel Empresa { get; set; }

		public int FuncionarioId { get; set; }

		public virtual FuncionarioViewModel Funcionario { get; set; }

        public string StatusNome { get; set; }

        public int Status { get; set; }

        [DisplayName("Inicio de turno")]
        [Required(ErrorMessage = "Prencher inicio de turno")]
        [MaxLength(8, ErrorMessage = "Máximo de 8 caracteres")]
        public string HoraEntrada { get; set; }

        [DisplayName("Fim de turno")]
        [Required(ErrorMessage = "Prencher fim de turno")]
        [MaxLength(8, ErrorMessage = "Máximo de 8 caracteres")]
        public string HoraSaida { get; set; }

        //public virtual ICollection<RiscoFuncionarioViewModel> RiscosFuncionario { get; set; }

        [DisplayName("Admissão")]
        [Required(ErrorMessage = "Prencher Admissão")]
        [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres")]
        public string Admissao { get; set; }

        public string Demissao { get; set; }

        public int CBOId { get; set; }

        public virtual CBOViewModel CBO { get; set; }

		public int SetorId { get; set; }

		public virtual SetorViewModel Setor { get; set; }

		public int EscalaId { get; set; }

		public virtual EscalaViewModel Escala { get; set; }

		public bool Delete { get; set; }
	}
}
