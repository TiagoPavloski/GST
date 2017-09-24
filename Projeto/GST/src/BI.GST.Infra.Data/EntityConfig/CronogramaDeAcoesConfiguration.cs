using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class CronogramaDeAcoesConfiguration : EntityTypeConfiguration<CronogramaDeAcoes>
  {
    public CronogramaDeAcoesConfiguration()
    {
      HasKey(e => e.CronogramaDeAcoesId);

      Property(c => c.Atividade)
        .HasMaxLength(150)
        .IsRequired();
        }
  }
}