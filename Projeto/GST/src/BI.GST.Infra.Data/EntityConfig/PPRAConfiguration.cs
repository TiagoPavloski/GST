using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class PPRAConfiguration : EntityTypeConfiguration<PPRA>
  {
    public PPRAConfiguration()
    {
      HasKey(e => e.PPRAId);
    }
  }
}