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
            .HasMaxLength(50);


            Property(c => c.TempoExposicao)
            .HasMaxLength(50);


            Property(c => c.Fonte)
            .HasMaxLength(100);


            Property(c => c.Efeito)
           .HasMaxLength(100);


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