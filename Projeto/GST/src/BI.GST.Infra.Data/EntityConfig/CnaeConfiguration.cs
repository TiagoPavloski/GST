using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class CnaeConfiguration : EntityTypeConfiguration<Cnae>
  {
    public CnaeConfiguration()
    {
      HasKey(e => e.CnaeId);
    }
  }
}