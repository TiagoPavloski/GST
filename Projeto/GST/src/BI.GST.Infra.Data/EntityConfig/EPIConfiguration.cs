using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class EPIConfiguration : EntityTypeConfiguration<EPI>
  {
    public EPIConfiguration()
    {
            HasKey(e => e.EPIId);

            Property(e => e.Nome)
                      .IsRequired()
                      .HasMaxLength(40);

            Property(c => c.Status)
                      .IsRequired();
        }
  }
}