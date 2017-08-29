using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteAmbientalConfiguration : EntityTypeConfiguration<AgenteAmbiental>
  {
    public AgenteAmbientalConfiguration()
    {
      HasKey(e => e.AgenteAmbientalId);
    }
  }
}