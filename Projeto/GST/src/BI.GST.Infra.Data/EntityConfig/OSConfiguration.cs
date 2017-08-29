using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class OSConfiguration : EntityTypeConfiguration<OS>
  {
    public OSConfiguration()
    {
      HasKey(e => e.OsId);
    }
  }
}