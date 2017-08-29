using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class FuncionarioEmpresaConfiguration : EntityTypeConfiguration<FuncionarioEmpresa>
  {
    public FuncionarioEmpresaConfiguration()
    {
      HasKey(e => e.FuncionarioEmpresaId);
    }
  }
}