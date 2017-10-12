using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class RiscoCBOConfiguration : EntityTypeConfiguration<RiscoCBO>
    {
        public RiscoCBOConfiguration()
        {
            HasKey(e => e.RiscoCBOId);

            Property(e => e.Consequencias)
                      .IsRequired()
                      .HasMaxLength(100);

            Property(e => e.MedidasPreventivas)
                    .IsRequired()
                    .HasMaxLength(100);
        }
    }
}