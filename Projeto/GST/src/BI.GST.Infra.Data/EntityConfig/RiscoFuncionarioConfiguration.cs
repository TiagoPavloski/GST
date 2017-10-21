using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class RiscoFuncionarioConfiguration : EntityTypeConfiguration<RiscoFuncionario>
    {
        public RiscoFuncionarioConfiguration()
        {
            HasKey(e => e.RiscoFuncionarioId)
            .HasRequired<AgenteRiscoCBO>(a => a.AgenteRiscoCBO)
               .WithMany(r => r.RiscosFuncionario)
                .HasForeignKey<int>(a => a.AgenteRiscoCBOId);

            HasRequired<FonteRiscoCBO>(a => a.FonteRiscoCBO)
                .WithMany(r => r.RiscosFuncionario)
                .HasForeignKey<int>(a => a.FonteRiscoCBOId);

            HasRequired<AgenteCausadorCBO>(a => a.AgenteCausadorCBO)
                .WithMany(r => r.RiscosFuncionario)
                .HasForeignKey<int>(a => a.AgenteCausadorCBOId);

            Property(c => c.Nome)
           .HasMaxLength(200)
           .IsRequired();

            Property(c => c.Consequencias)
           .HasMaxLength(200)
           .IsRequired();

            Property(c => c.MedidasPreventivas)
           .HasMaxLength(200)
           .IsRequired();

            Property(c => c.Delete)
           .IsRequired();



        }
    }
}