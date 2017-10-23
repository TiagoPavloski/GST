using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
	public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
	{
		public EmpresaConfiguration()
		{
			HasKey(e => e.EmpresaId)

				.HasMany<Cnae>(c => c.CnaeSecundarios)
				.WithMany(c => c.Empresas)
				.Map(cs =>
				{
					cs.MapLeftKey("EmpresaId");
					cs.MapRightKey("CnaeSecundarioId");
					cs.ToTable("CnaeSecundarioEmpresa");
				});

			Property(e => e.NomeFantasia)
			.HasMaxLength(150)
			.IsRequired();

			Property(e => e.RazaoSocial)
		    .HasMaxLength(150)
		    .IsRequired();

			Property(e => e.RazaoSocial)
			.HasMaxLength(20)
			.IsRequired();

			Property(e => e.Email)
			.HasMaxLength(30)
			.IsRequired();


		}
	}
}