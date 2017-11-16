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

            Property(c => c.Frequencia)
           .HasMaxLength(150);

            Property(c => c.TempoExposicao)
           .HasMaxLength(100);

            Property(c => c.FonteGeradora)
           .HasMaxLength(200);

            Property(c => c.Efeito)
           .HasMaxLength(150);

            Property(c => c.Orientacao)
           .IsMaxLength();

            Property(c => c.MedidasPropostas)
           .IsMaxLength();

            Property(c => c.Tecnica)
           .HasMaxLength(100);

            Property(c => c.FundamentacaoLegal)
           .HasMaxLength(200);

            Property(c => c.Delete);
           
        }
  }
}