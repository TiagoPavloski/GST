
using System.Collections.Generic;

namespace BI.GST.Domain.Entities
{
    public class FuncionarioEmpresa
    {
        public int FuncionarioEmpresaId { get; set; }

        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }

        public int FuncionarioId { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        public int Status { get; set; }

        public string HoraEntrada { get; set; }

        public string HoraSaida { get; set; }

        public virtual ICollection<RiscoFuncionario> RiscosFuncionario { get; set; }

        public string Admissao { get; set; }

        public int CBOId { get; set; }

        public virtual CBO CBO { get; set; }

        public int SetorId { get; set; }

        public virtual Setor Setor { get; set; }

        public int EscalaId { get; set; }

        public virtual Escala Escala { get; set; }

        public string Demissao { get; set; }

        public bool Delete { get; set; }
    }
}
