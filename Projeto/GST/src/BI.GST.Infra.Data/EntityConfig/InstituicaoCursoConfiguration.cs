using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class InstituicaoCursoConfiguration : EntityTypeConfiguration<InstituicaoCurso>
  {
    public InstituicaoCursoConfiguration()
    {
      HasKey(e => e.InstituicaoCursoId);

            Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(55);
    }
  }
}