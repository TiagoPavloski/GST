using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteErgonomicoConfiguration : EntityTypeConfiguration<AgenteErgonomico>
  {
    public AgenteErgonomicoConfiguration()
    {
      HasKey(e => e.AgenteErgonomicoId);

            Property(c => c.Nome)
           .HasMaxLength(150)
           .IsRequired();

            Property(c => c.FonteGeradora)
           .HasMaxLength(200);

            Property(c => c.Orientacao)
           .IsMaxLength();
         
            Property(c => c.Delete);
        }
  }
}