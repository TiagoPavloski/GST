using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class FonteRiscoCBOConfiguration : EntityTypeConfiguration<FonteRiscoCBO>
  {
    public FonteRiscoCBOConfiguration()
    {
      HasKey(e => e.FonteRiscoCBOId);

            Property(e => e.Nome)
                      .IsRequired()
                      .HasMaxLength(55);

            Property(e => e.Status)
                .IsRequired();

    }
  }
}