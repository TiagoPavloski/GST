using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class AgenteAcidenteConfiguration : EntityTypeConfiguration<AgenteAcidente>
    {
        public AgenteAcidenteConfiguration()
        {

            HasKey(e => e.AgenteAcidenteId);

            Property(c => c.Nome)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.Frequencia)
            .HasMaxLength(150)
            .IsRequired();

            Property(c => c.TempoExposicao)
            .HasMaxLength(100)
            .IsRequired();

            Property(c => c.Fonte)
            .HasMaxLength(200)
            .IsRequired();

            Property(c => c.Efeito)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.Orientacao)
           .HasMaxLength(500)
           .IsRequired();

            Property(c => c.MedidasPropostas)
           .HasMaxLength(200)
           .IsRequired();

            Property(c => c.Tecnica)
           .HasMaxLength(100)
           .IsRequired();

            Property(c => c.FundamentacaoLegal)
           .HasMaxLength(200)
           .IsRequired();

            Property(c => c.Delete)
           .IsRequired();
        }
    }
}