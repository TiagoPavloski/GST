using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class FinanceiroParcelaConfiguration : EntityTypeConfiguration<FinanceiroParcela>
    {
        public FinanceiroParcelaConfiguration()
        {
            HasKey(e => e.FinanceiroParcelaId);
        }
    }
}
