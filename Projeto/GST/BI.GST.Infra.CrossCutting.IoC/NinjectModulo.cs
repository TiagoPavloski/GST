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

      //Servicos
      Bind<ITipoCursoService>().To<TipoCursoService>();

      //Data Repository
      Bind<ITipoCursoRepository>().To<TipoCursoRepository>();

      //Data Configuration
      Bind<IContextManager>().To<ContextManager>();
      Bind<IUnitOfWork>().To<UnitOfWork>();
    }
  }
}
