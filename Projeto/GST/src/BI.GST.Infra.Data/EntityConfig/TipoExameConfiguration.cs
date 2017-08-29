using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class TipoExameConfiguration : EntityTypeConfiguration<TipoExame>
  {
    public TipoExameConfiguration()
    {
      HasKey(e => e.TipoExameId);
    }
  }
}