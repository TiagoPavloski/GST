using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class SESMTEmpresaConfiguration : EntityTypeConfiguration<SESMTEmpresa>
    {
        public SESMTEmpresaConfiguration()
        {
            HasKey(e => e.SESMTEmpresaID);
        }
    }
}
