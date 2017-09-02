using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class CursoConfiguration : EntityTypeConfiguration<Curso>
  {
    public CursoConfiguration()
    {
      HasKey(e => e.CursoId);

      Property(c => c.Status)
           .IsRequired();

      Property(c => c.Data)
               .HasMaxLength(10)
               .IsRequired();

      Property(c => c.Delete)
              .IsRequired();
    }
  }
}