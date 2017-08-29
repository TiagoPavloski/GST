using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class ColaboradorConfiguration : EntityTypeConfiguration<Colaborador>
  {
    public ColaboradorConfiguration()
    {
      HasKey(e => e.ColaboradorId);
    }
  }
}