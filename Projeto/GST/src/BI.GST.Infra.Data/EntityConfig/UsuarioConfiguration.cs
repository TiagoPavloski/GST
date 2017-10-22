using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
	public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
	{
		public UsuarioConfiguration()
		{
			HasKey(e => e.UsuarioId)

			.HasRequired<Empresa>(s => s.Empresa)
			.WithMany(g => g.Usuarios)
			.HasForeignKey<int>(s => s.EmpresaId);
		}
	}
}