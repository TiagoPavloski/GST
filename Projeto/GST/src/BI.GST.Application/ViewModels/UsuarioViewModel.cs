using System.Collections.Generic;

namespace BI.GST.Application.ViewModels
{
	public class UsuarioViewModel
	{
		public UsuarioViewModel()
		{
		}
		public int UsuarioId { get; set; }

		public string Nome { get; set; }

		public string Email { get; set; }

		public string Senha { get; set; }

		public bool Delete { get; set; }

	}
}
