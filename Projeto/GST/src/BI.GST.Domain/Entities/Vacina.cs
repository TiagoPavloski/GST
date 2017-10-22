namespace BI.GST.Domain.Entities
{
	public class Vacina
	{
		public int VacinaId { get; set; }

		public int FuncionarioId { get; set; }

		public int TipoVacinaId { get; set; }

		public string Data { get; set; }

		public bool Renovado { get; set; }

		public bool Delete { get; set; }

		public virtual Funcionario Funcionario { get; set; }
		public virtual TipoVacina TipoVacina { get; set; }
	}
}
