using Ninject.Modules;
using BI.GST.Application;
using BI.GST.Application.Interface;
using BI.GST.Domain.Interface.IRepository;
using BI.GST.Domain.Services;
using BI.GST.Infra.Data.Context;
using BI.GST.Infra.Data.Interface;
using BI.GST.Infra.Data.Repository;
using BI.GST.Infra.Data.UoW;
using BI.GST.Application.AppService;
using BI.GST.Domain.Interface.IService;

namespace BI.GST.Infra.CrossCutting.IoC
{
	public class NinjectModulo : NinjectModule
	{
		public override void Load()
		{
			//Application
			Bind<ITipoCursoAppService>().To<TipoCursoAppService>();
			Bind<ITipoExameAppService>().To<TipoExameAppService>();
			Bind<ITipoVacinaAppService>().To<TipoVacinaAppService>();
			Bind<ICursoAppService>().To<CursoAppService>();
			Bind<IExameAppService>().To<ExameAppService>();
			Bind<IVacinaAppService>().To<VacinaAppService>();
			Bind<IFuncionarioAppService>().To<FuncionarioAppService>();
			Bind<IUFAppService>().To<UFAppService>();
			Bind<ITelefoneAppService>().To<TelefoneAppService>();
			Bind<IEnderecoAppService>().To<EnderecoAppService>();

			//Servicos
			Bind<ITipoCursoService>().To<TipoCursoService>();
			Bind<ITipoExameService>().To<TipoExameService>();
			Bind<ITipoVacinaService>().To<TipoVacinaService>();
			Bind<ICursoService>().To<CursoService>();
			Bind<IExameService>().To<ExameService>();
			Bind<IVacinaService>().To<VacinaService>();
			Bind<IFuncionarioService>().To<FuncionarioService>();
			Bind<IUFService>().To<UFService>();
			Bind<ITelefoneService>().To<TelefoneService>();
			Bind<IEnderecoService>().To<EnderecoService>();

			//Data Repository
			Bind<ITipoCursoRepository>().To<TipoCursoRepository>();
			Bind<ITipoExameRepository>().To<TipoExameRepository>();
			Bind<ITipoVacinaRepository>().To<TipoVacinaRepository>();
			Bind<ICursoRepository>().To<CursoRepository>();
			Bind<IExameRepository>().To<ExameRepository>();
			Bind<IVacinaRepository>().To<VacinaRepository>();
			Bind<IFuncionarioRepository>().To<FuncionarioRepository>();
			Bind<IUFRepository>().To<UFRepository>();
			Bind<ITelefoneRepository>().To<TelefoneRepository>();
			Bind<IEnderecoRepository>().To<EnderecoRepository>();

			//Data Configuration
			Bind<IContextManager>().To<ContextManager>();
			Bind<IUnitOfWork>().To<UnitOfWork>();
		}
	}
}
