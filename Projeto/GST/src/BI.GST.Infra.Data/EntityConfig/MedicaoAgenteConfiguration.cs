using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class MedicaoAgenteConfiguration : EntityTypeConfiguration<MedicaoAgente>
  {
    public MedicaoAgenteConfiguration()
    {
      HasKey(e => e.MedicaoAgenteId);
    }
  }
}