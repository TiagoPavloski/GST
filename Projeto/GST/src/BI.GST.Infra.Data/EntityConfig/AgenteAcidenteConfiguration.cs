using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteAcidenteConfiguration : EntityTypeConfiguration<AgenteAcidente>
  {
    public AgenteAcidenteConfiguration()
    {
      HasKey(e => e.AgenteAcidenteId);
    }
  }
}