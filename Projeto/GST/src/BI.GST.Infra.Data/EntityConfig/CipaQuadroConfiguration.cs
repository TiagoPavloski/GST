using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class CipaQuadroConfiguration : EntityTypeConfiguration<CipaQuadro>
    {
        public CipaQuadroConfiguration()
        {
            HasKey(e => e.CipaQuadroId);

        }
          
    }
}
