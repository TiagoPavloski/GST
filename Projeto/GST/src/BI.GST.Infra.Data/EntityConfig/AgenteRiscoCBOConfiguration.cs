using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteRiscoCBOConfiguration : EntityTypeConfiguration<AgenteRiscoCBO>
  {
    public AgenteRiscoCBOConfiguration()
    {
      HasKey(e => e.AgenteRiscoCBOId);
    }
  }
}