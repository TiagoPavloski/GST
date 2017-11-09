using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.GST.Domain.Entities
{
	public class Funcionario : Pessoa
    { 
        public int FuncionarioId { get; set; }

        public int Status { get; set; }

        public bool Responsavel { get; set; }

        public int EmpresaId { get; set; }

        public string HoraEntrada { get; set; }

        public string HoraSaida { get; set; }

        public string Admissao { get; set; }

        public int CBOId { get; set; }    

        public int SetorId { get; set; }
    
        public int EscalaId { get; set; }

        public string Demissao { get; set; }

        public bool Delete { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual CBO CBO { get; set; }
        public virtual Setor Setor { get; set; }
        public virtual Escala Escala { get; set; }
        public virtual IEnumerable<Curso> Cursos { get; set; }
    }
}
