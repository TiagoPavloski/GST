using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class TipoSetorConfiguration : EntityTypeConfiguration<TipoSetor>
  {
    public TipoSetorConfiguration()
    {
      HasKey(e => e.TipoSetorId);
    }
  }
}