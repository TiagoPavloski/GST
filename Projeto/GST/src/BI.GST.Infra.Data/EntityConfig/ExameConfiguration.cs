using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
	public class ExameConfiguration : EntityTypeConfiguration<Exame>
	{
		public ExameConfiguration()
		{
			HasKey(e => e.ExameId);

			Property(c => c.Data)
					 .HasMaxLength(10)
					 .IsRequired();

			Property(c => c.Delete)
					.IsRequired();
		}
	}
}