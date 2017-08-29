using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class FonteRiscoCBOConfiguration : EntityTypeConfiguration<FonteRiscoCBO>
  {
    public FonteRiscoCBOConfiguration()
    {
      HasKey(e => e.FonteRiscoCBOId);
    }
  }
}