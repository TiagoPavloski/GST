using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AnexoConfiguration : EntityTypeConfiguration<Anexo>
  {
    public AnexoConfiguration()
    {
      HasKey(e => e.AnexoID);
    }
  }
}