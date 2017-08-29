using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class UFConfiguration : EntityTypeConfiguration<UF>
  {
    public UFConfiguration()
    {
      HasKey(e => e.UFId);
    }
  }
}