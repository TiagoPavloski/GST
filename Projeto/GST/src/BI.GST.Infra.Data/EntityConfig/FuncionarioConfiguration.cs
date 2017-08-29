using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class FuncionarioConfiguration : EntityTypeConfiguration<Funcionario>
  {
    public FuncionarioConfiguration()
    {
      HasKey(e => e.FuncionarioId);
    }
  }
}