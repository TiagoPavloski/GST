using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
	public class Empresa
	{
		public Empresa()
		{
			Telefones = new List<Telefone>();
			CnaeSecundarios = new List<Cnae>();
			Setores = new List<Setor>();
			Responsaveis = new List<Funcionario>();
			Usuarios = new List<Usuario>();
		}
		public int EmpresaId { get; set; }

		public string NomeFantasia { get; set; }

		public string RazaoSocial { get; set; }

		public string CNPJ { get; set; }

		public string Email { get; set; }

		public int? CnaeId { get; set; }

		public int EnderecoId { get; set; }

		public string Logo { get; set; }

		public bool Delete { get; set; }


		[ForeignKey("CnaeId")]
		public virtual Cnae CnaePrincipal { get; set; }
		public virtual ICollection<Telefone> Telefones { get; set; }
		public virtual Endereco Endereco { get; set; }
		public virtual ICollection<Cnae> CnaeSecundarios { get; set; }
		public virtual ICollection<Setor> Setores { get; set; }
		public virtual ICollection<Funcionario> Responsaveis { get; set; }
		public virtual ICollection<Usuario> Usuarios { get; set; }
	}
}
