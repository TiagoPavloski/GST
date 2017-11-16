using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteFisicoConfiguration : EntityTypeConfiguration<AgenteFisico>
  {
    public AgenteFisicoConfiguration()
    {
      HasKey(e => e.AgenteFisicoId);

            Property(c => c.Nome)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.LimiteTolerancia)
           .HasMaxLength(150);

            Property(c => c.NivelAcao)
           .HasMaxLength(150);

            Property(c => c.Frequencia)
            .HasMaxLength(150);

            Property(c => c.TempoExposicao)
            .HasMaxLength(100);

            Property(c => c.Tecnica)
           .HasMaxLength(150);

            Property(c => c.Fonte)
           .HasMaxLength(200);

            Property(c => c.EPI)
           .HasMaxLength(150);

            Property(c => c.EPC)
           .HasMaxLength(150);

            Property(c => c.Caracteristicas)
           .HasMaxLength(150);

            Property(c => c.Orientacao)
           .IsMaxLength();

            Property(c => c.MedidasPropostas)
           .IsMaxLength();

            Property(c => c.MedidasExistentes)
           .HasMaxLength(150);

            Property(c => c.AnaliseQualitativa)
           .HasMaxLength(150);

            Property(c => c.EfeitosPotenciais)
           .HasMaxLength(150);

            Property(c => c.FundamentacaoLegal)
           .HasMaxLength(200);

            Property(c => c.Observacao)
           .IsMaxLength();

            Property(c => c.Delete);
        }
  }
}