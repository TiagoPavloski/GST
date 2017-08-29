using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
            EnderecoEx = new List<EnderecoEx>();
        }

        public Guid ClienteId { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual ICollection<EnderecoEx> EnderecoEx { get; set; }

    }
}
