using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class VacinaConfiguration : EntityTypeConfiguration<Vacina>
  {
    public VacinaConfiguration()
    {
      HasKey(e => e.VacinaId);
    }
  }
}