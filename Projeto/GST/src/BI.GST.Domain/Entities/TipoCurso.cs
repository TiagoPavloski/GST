namespace BI.GST.Domain.Entities
{
	public class TipoCurso
	{
		public int TipoCursoId { get; set; }

		public string Nome { get; set; }

		public int MesesValidade { get; set; }

		public bool Delete { get; set; }
	}
}
