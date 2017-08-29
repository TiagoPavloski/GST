using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class EnderecoEx
    {
        public EnderecoEx()
        {
            EnderecoExId = Guid.NewGuid();
        }

        public Guid EnderecoExId { get; set; }

        public string CEP { get; set; }

        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }

        public string Complemento { get; set; }

        public string Referencia { get; set; }


        public Guid ClienteId { get; set; }  //Todo endereço pertence a um Cliente

        public virtual Cliente Cliente { get; set; } //Para o CodeFirst saber que esta classe se relaciona com o Cliente


    }
}
