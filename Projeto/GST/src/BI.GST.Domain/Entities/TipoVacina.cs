namespace BI.GST.Domain.Entities
{
	public class TipoVacina
	{
		public int TipoVacinaId { get; set; }

		public string Nome { get; set; }

		public int MesesValidade { get; set; }

		public bool Delete { get; set; }
	}
}
