using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class SetorConfiguration : EntityTypeConfiguration<Setor>
    {
        public SetorConfiguration()
        {
            HasKey(e => e.SetorId)

                .HasMany<AgenteAcidente>(c => c.AgenteAcidentes)
                .WithMany(c => c.Setores)
                .Map(cs =>
                {
                    cs.MapLeftKey("SetorId");
                    cs.MapRightKey("AgenteAcidenteId");
                    cs.ToTable("AgenteAcidenteSetor");
                });

                 HasMany<AgenteBiologico>(c => c.AgenteBiologicos)
                .WithMany(c => c.Setores)
                .Map(cs =>
                {
                    cs.MapLeftKey("SetorId");
                    cs.MapRightKey("AgenteBiologicoId");
                    cs.ToTable("AgenteBiologicoSetor");
                });

                HasMany<AgenteErgonomico>(c => c.AgenteErgonomicos)
                .WithMany(c => c.Setores)
                .Map(cs =>
                {
                    cs.MapLeftKey("SetorId");
                    cs.MapRightKey("AgenteErgonomicoId");
                    cs.ToTable("AgenteErgonomicoSetor");
                });

                HasMany<AgenteFisico>(c => c.AgenteFisicos)
                .WithMany(c => c.Setores)
                .Map(cs =>
                {
                    cs.MapLeftKey("SetorId");
                    cs.MapRightKey("AgenteFisicoId");
                    cs.ToTable("AgenteFisicoSetor");
                });

                HasMany<AgenteQuimico>(c => c.AgenteQuimicos)
                .WithMany(c => c.Setores)
                .Map(cs =>
                {
                    cs.MapLeftKey("SetorId");
                    cs.MapRightKey("AgenteQuimicoId");
                    cs.ToTable("AgenteQuimicoSetor");
                });

            Property(c => c.Nome)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.Descricao)
           .HasMaxLength(200);

            Property(c => c.Delete);
        }
    }
}