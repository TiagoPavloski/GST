using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class FinanceiroConfiguration : EntityTypeConfiguration<Financeiro>
  {
    public FinanceiroConfiguration()
    {
      HasKey(e => e.FinanceiroId);
    }
  }
}