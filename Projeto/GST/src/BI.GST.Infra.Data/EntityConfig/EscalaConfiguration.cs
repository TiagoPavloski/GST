using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class EscalaConfiguration : EntityTypeConfiguration<Escala>
  {
    public EscalaConfiguration()
    {
      HasKey(e => e.EscalaId);

      Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(25);

      Property(e => e.HoraAlmoco)
                .HasMaxLength(15);
    }
  }
}