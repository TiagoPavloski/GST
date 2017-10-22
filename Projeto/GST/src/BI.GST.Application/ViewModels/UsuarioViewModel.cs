using System.Collections.Generic;

namespace BI.GST.Application.ViewModels
{
	public class UsuarioViewModel
	{
		public int UsuarioId { get; set; }

		public string Nome { get; set; }

		public string Email { get; set; }

		public string Senha { get; set; }

		public int EmpresaId { get; set; }

		public bool Delete { get; set; }


		public virtual EmpresaViewModel Empresa { get; set; }
	}
}
