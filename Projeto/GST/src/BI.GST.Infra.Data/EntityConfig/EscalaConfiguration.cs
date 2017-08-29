using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class EscalaConfiguration : EntityTypeConfiguration<Escala>
  {
    public EscalaConfiguration()
    {
      HasKey(e => e.EscalaId);
    }
  }
}