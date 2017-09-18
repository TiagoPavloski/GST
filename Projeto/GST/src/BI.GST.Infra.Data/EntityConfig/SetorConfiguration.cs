using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class SetorConfiguration : EntityTypeConfiguration<Setor>
    {
        public SetorConfiguration()
        {
            HasKey(e => e.SetorId);

            Property(c => c.Nome)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.Descricao)
           .HasMaxLength(200)
           .IsRequired();

            Property(c => c.Status)
           .IsRequired();

            Property(c => c.Delete)
           .IsRequired();
        }
    }
}