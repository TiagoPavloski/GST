using BI.GST.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class TipoCursoConfiguration : EntityTypeConfiguration<TipoCurso>
  {
    public TipoCursoConfiguration()
    {
      HasKey(e => e.TipoCursoId);

      Property(c => c.Nome)
           .HasMaxLength(150)
           .IsRequired();

      Property(c => c.MesesValidade)
               .IsRequired();

      Property(c => c.Delete)
              .IsRequired();

    }
  }
}