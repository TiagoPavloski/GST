using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class ClassificacaoEfeitoConfiguration : EntityTypeConfiguration<ClassificacaoEfeito>
  {
    public ClassificacaoEfeitoConfiguration()
    {
      HasKey(e => e.ClassificacaoEfeitoId);
    }
  }
}