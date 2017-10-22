using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
	public class TipoVacinaConfiguration : EntityTypeConfiguration<TipoVacina>
	{
		public TipoVacinaConfiguration()
		{
			HasKey(e => e.TipoVacinaId);

			Property(c => c.Nome)
					 .HasMaxLength(150)
					 .IsRequired();

			Property(c => c.MesesValidade)
					 .IsRequired();

			Property(c => c.Delete)
			  .IsRequired();
		}
	}
}