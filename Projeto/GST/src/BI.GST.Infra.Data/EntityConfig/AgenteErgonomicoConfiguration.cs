using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteErgonomicoConfiguration : EntityTypeConfiguration<AgenteErgonomico>
  {
    public AgenteErgonomicoConfiguration()
    {
      HasKey(e => e.AgenteErgonomicoId);
    }
  }
}