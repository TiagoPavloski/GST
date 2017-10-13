using System.Data.Entity;

namespace BI.GST.Infra.Data.Context
{
	public class ProjetoContextInitializer : DropCreateDatabaseIfModelChanges<ProjetoContext>
	{
		protected override void Seed(ProjetoContext context)
		{
			base.Seed(context);

			CriarMassaDadosTeste(context);
			
		}

		private void CriarMassaDadosTeste(ProjetoContext ctx)
		{
			ctx.Empresas.Add(
				new Domain.Entities.Empresa()
				{
					NomeFantasia = "shifuhd"
				});
		}
	}
}
