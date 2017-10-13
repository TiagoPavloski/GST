namespace BI.GST.Application.ViewModels
{
	public class FuncionarioEmpresaViewModel
	{
		public int FuncionarioEmpresaId { get; set; }

		public int EmpresaId { get; set; }

		public virtual EmpresaViewModel Empresa { get; set; }

		public int FuncionarioId { get; set; }

		public virtual FuncionarioViewModel Funcionario { get; set; }

		public int Status { get; set; }

		public string HoraEntrada { get; set; }

		public string HoraSaida { get; set; }

		//public virtual ICollection<RiscoFuncionarioViewModel> RiscosFuncionario { get; set; }

		public string Admissao { get; set; }

		//public virtual CBOViewModel CBO { get; set; }

		public int SetorId { get; set; }

		public virtual SetorViewModel Setor { get; set; }

		public int EscalaId { get; set; }

		public virtual EscalaViewModel Escala { get; set; }

		public bool Delete { get; set; }
	}
}
