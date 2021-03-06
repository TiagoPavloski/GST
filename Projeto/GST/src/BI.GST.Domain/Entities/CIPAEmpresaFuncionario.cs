﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class CIPAEmpresaFuncionario
    {
        public int CIPAEmpresaFuncionarioId { get; set; }

        public int CipaEmpresaId { get; set; }

        public virtual CIPAEmpresa CipaEmpresa { get; set; }

        public int FuncionarioId { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        public bool Efetivo { get; set; }

        public bool Reeleito { get; set; }

        public bool Delete { get; set; }

    }
}
