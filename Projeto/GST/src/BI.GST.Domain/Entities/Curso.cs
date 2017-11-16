using System.ComponentModel.DataAnnotations.Schema;

namespace BI.GST.Domain.Entities
{
	public class Curso
	{
		public int CursoId { get; set; }

		public int FuncionarioId { get; set; }

		public int TipoCursoId { get; set; }

		public string Data { get; set; }

		public bool Renovado { get; set; }

		public bool Delete { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual Funcionario Funcionario { get; set; }
		public virtual TipoCurso TipoCurso { get; set; }
	}
}
