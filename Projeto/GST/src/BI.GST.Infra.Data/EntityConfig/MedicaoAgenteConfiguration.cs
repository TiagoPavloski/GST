using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class MedicaoAgenteConfiguration : EntityTypeConfiguration<MedicaoAgente>
  {
    public MedicaoAgenteConfiguration()
    {
      HasKey(e => e.MedicaoAgenteId);

            Property(c => c.Data)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.Medicao)
           .HasMaxLength(200);

            Property(c => c.ItemDemonstraAmbientais)
           .HasMaxLength(150);

            Property(c => c.Delete);
        }
  }
}