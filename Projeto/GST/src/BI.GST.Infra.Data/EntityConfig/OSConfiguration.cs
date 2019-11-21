using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
	public class OSConfiguration : EntityTypeConfiguration<OS>
	{
		public OSConfiguration()
		{
			HasKey(e => e.OsId);

			Property(c => c.DataElaboracao)
					 .HasMaxLength(10)
					 .IsRequired();

			Property(c => c.DataRevisao)
				 .HasMaxLength(10)
				 .IsRequired();

			Property(c => c.EPIRecomendado)
				 .HasMaxLength(800)
				 .IsRequired();

			Property(c => c.Recomentacoes)
				 .HasMaxLength(800)
				 .IsRequired();
		}
	}
}