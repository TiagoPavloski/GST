using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
	public class TelefoneConfiguration : EntityTypeConfiguration<Telefone>
	{
		public TelefoneConfiguration()
		{
			HasKey(e => e.TelefoneId);

			Property(c => c.Numero)
			   .HasMaxLength(9);
		}
	}
}