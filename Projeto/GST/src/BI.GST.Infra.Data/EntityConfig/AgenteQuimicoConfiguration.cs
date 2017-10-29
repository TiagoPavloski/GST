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
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.Frequencia)
            .HasMaxLength(150)
            .IsRequired();

            Property(c => c.TempoExposicao)
            .HasMaxLength(100)
            .IsRequired();

            Property(c => c.Tecnica)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.Metodo)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.Fonte)
            .HasMaxLength(200)
            .IsRequired();

            Property(c => c.EPI)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.EPC)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.Caracteristicas)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.Orientacao)
           .HasMaxLength(500)
           .IsRequired();

            Property(c => c.MedidasPropostas)
           .HasMaxLength(200)
           .IsRequired();

            Property(c => c.MedidasExistentes)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.AnaliseQualitativa)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.EfeitosPotenciais)
           .HasMaxLength(150)
           .IsRequired();
            
            Property(c => c.FundamentacaoLegal)
           .HasMaxLength(500)
           .IsRequired();

            Property(c => c.Observacao)
           .HasMaxLength(500)
           .IsRequired();

            Property(c => c.Delete)
           .IsRequired();
        }
  }
}