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

      //Property(p => p.TipoCursoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

    }
  }
}