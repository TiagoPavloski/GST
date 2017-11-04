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
                .HasMaxLength(400);

            Property(e => e.CodigoCBO)
                .IsRequired()
                .HasMaxLength(20);

        }
    }
}