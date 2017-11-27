using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class CBOConfiguration : EntityTypeConfiguration<CBO>
    {
        public CBOConfiguration()
        {
            HasKey(e => e.CBOId);

            Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(70);

            Property(e => e.Descricao)
                .HasMaxLength(800);

            Property(e => e.CodigoCBO)
                .IsRequired()
                .HasMaxLength(20);

            HasMany<RiscoCBO>(c => c.RiscoCBOs)
                .WithMany(c => c.CBOs)
                .Map(cs =>
                {
                    cs.MapLeftKey("CBOId");
                    cs.MapRightKey("RiscoCBOId");
                    cs.ToTable("CBORiscoCBO");
                });

            HasMany<TipoCurso>(c => c.TipoCursos)
            .WithMany(c => c.CBOs)
            .Map(cs =>
              {
                  cs.MapLeftKey("CBOId");
                  cs.MapRightKey("TipoCursoId");
                  cs.ToTable("CBOTipoCurso");
              });

             HasMany<TipoExame>(c => c.TipoExames)
              .WithMany(c => c.CBOs)
              .Map(cs =>
              {
                  cs.MapLeftKey("CBOId");
                  cs.MapRightKey("TipoExameId");
                  cs.ToTable("CBOTipoExame");
              });

             HasMany<TipoVacina>(c => c.TipoVacinas)
              .WithMany(c => c.CBOs)
              .Map(cs =>
              {
                  cs.MapLeftKey("CBOId");
                  cs.MapRightKey("TipoVacinaId");
                  cs.ToTable("CBOTipoVacina");
              });



        }
    }
}