﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
	public class Usuario
	{
		public int UsuarioId { get; set; }

		public string Nome { get; set; }

		public string Email { get; set; }

		public string Senha { get; set; }

		public int EmpresaId { get; set; }

		public bool Delete { get; set; }


		public virtual Empresa Empresa { get; set; }
	}
}
