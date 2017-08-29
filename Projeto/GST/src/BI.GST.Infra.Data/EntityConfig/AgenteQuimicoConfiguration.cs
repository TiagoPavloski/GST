using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteQuimicoConfiguration : EntityTypeConfiguration<AgenteQuimico>
  {
    public AgenteQuimicoConfiguration()
    {
      HasKey(e => e.AgenteQuimicoId);
    }
  }
}