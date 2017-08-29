using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class CursoConfiguration : EntityTypeConfiguration<Curso>
  {
    public CursoConfiguration()
    {
      HasKey(e => e.CursoId);
    }
  }
}