using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class EmpresaUtilizadora
    {
        public EmpresaUtilizadora()
        {
            Telefones = new List<Telefone>();
        }
        public int EmpresaUtilizadoraId { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CNPJ { get; set; }

        public int EnderecoId { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public bool Delete { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
