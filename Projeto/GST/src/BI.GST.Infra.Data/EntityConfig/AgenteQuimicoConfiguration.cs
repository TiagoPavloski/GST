using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteQuimicoConfiguration : EntityTypeConfiguration<AgenteQuimico>
  {
    public AgenteQuimicoConfiguration()
    {
      HasKey(e => e.AgenteQuimicoId);

            Property(c => c.Nome)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.LimiteTolerancia)
           .HasMaxLength(150);

            Property(c => c.Frequencia)
            .HasMaxLength(150);

            Property(c => c.TempoExposicao)
            .HasMaxLength(100);

            Property(c => c.Tecnica)
           .IsMaxLength();

            Property(c => c.Metodo)
           .HasMaxLength(150);

            Property(c => c.Fonte)
            .HasMaxLength(200);

            Property(c => c.EPI)
           .HasMaxLength(150);

            Property(c => c.EPC)
           .HasMaxLength(150);

            Property(c => c.Caracteristicas)
           .IsMaxLength();

            Property(c => c.Orientacao)
           .IsMaxLength();

            Property(c => c.MedidasPropostas)
           .IsMaxLength();

            Property(c => c.MedidasExistentes)
           .IsMaxLength();

            Property(c => c.AnaliseQualitativa)
           .IsMaxLength();

            Property(c => c.EfeitosPotenciais)
           .IsMaxLength();

            Property(c => c.FundamentacaoLegal)
           .IsMaxLength();

            Property(c => c.Observacao)
           .IsMaxLength();

            Property(c => c.Delete);
        }
  }
}