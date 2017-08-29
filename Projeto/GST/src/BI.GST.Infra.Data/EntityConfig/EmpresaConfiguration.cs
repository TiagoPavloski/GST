using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
  {
    public EmpresaConfiguration()
    {
      HasKey(e => e.EmpresaId);
    }
  }
}