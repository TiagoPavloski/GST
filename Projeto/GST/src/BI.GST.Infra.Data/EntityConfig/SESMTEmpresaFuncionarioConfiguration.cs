using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class SESMTEmpresaFuncionarioConfiguration : EntityTypeConfiguration<SESMTEmpresaFuncionario>
    {
        public SESMTEmpresaFuncionarioConfiguration()
        {
            HasKey(e => e.SESMTEmpresaFuncionarioId);

        }
    }
}
