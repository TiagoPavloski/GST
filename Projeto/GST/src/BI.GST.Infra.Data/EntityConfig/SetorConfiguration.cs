using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class SetorConfiguration : EntityTypeConfiguration<Setor>
  {
    public SetorConfiguration()
    {
      HasKey(e => e.SetorId);
    }
  }
}