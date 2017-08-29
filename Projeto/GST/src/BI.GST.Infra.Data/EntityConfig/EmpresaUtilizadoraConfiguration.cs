using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class EmpresaUtilizadoraConfiguration : EntityTypeConfiguration<EmpresaUtilizadora>
  {
    public EmpresaUtilizadoraConfiguration()
    {
      HasKey(e => e.EmpresaUtilizadoraId);
    }
  }
}