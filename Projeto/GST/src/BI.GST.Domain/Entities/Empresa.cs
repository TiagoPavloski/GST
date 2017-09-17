using System;
using System.Collections.Generic;
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
            Enderecos = new List<Endereco>();
            Responsaveis = new List<Funcionario>();
            CnaeSecundarios = new List<Cnae>();
            Setores = new List<Setor>();
        }
        public int EmpresaId { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CNPJ { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }

        public virtual ICollection<Funcionario> Responsaveis { get; set; }

        public int CnaeId { get; set; }

        public virtual Cnae CnaePrincipal { get; set; }

        public virtual ICollection<Cnae> CnaeSecundarios { get; set; }

        public virtual ICollection<Setor> Setores { get; set; }

        public string Logo { get; set; }

        public bool Delete { get; set; }
    }
}
