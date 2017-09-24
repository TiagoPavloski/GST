using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteBiologicoConfiguration : EntityTypeConfiguration<AgenteBiologico>
  {
    public AgenteBiologicoConfiguration()
    {
      HasKey(e => e.AgenteBiologicoId);

            Property(c => c.Nome)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.FonteGeradora)
           .HasMaxLength(200)
           .IsRequired();

            Property(c => c.Orientacao)
           .HasMaxLength(500)
           .IsRequired();

            Property(c => c.Delete)
           .IsRequired();
        }
  }
}