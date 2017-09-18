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
            Bind<IAgenteErgonomicoAppService>().To<AgenteErgonomicoAppService>();
            Bind<ISetorAppService>().To<SetorAppService>();
            Bind<IAgenteAcidenteAppService>().To<AgenteAcidenteAppService>();
            Bind<IAgenteQuimicoAppService>().To<AgenteQuimicoAppService>();
            Bind<IAgenteFisicoAppService>().To<AgenteFisicoAppService>();
            Bind<IAgenteBiologicoAppService>().To<AgenteBiologicoAppService>();
            Bind<IMedicaoAgenteAppService>().To<MedicaoAgenteAppService>();
            Bind<IClassificacaoEfeitoAppService>().To<ClassificacaoEfeitoAppService>();
            Bind<IMeioPropagacaoAppService>().To<MeioPropagacaoAppService>();

            //Servicos
            Bind<ITipoCursoService>().To<TipoCursoService>();
            Bind<ITipoExameService>().To<TipoExameService>();
            Bind<ITipoVacinaService>().To<TipoVacinaService>();
            Bind<ICursoService>().To<CursoService>();
            Bind<IExameService>().To<ExameService>();
            Bind<IVacinaService>().To<VacinaService>();
            Bind<IFuncionarioService>().To<FuncionarioService>();
            Bind<IAgenteErgonomicoService>().To<AgenteErgonomicoService>();
            Bind<ISetorService>().To<SetorService>();
            Bind<IAgenteAcidenteService>().To<AgenteAcidenteService>();
            Bind<IAgenteQuimicoService>().To<AgenteQuimicoService>();
            Bind<IAgenteFisicoService>().To<AgenteFisicoService>();
            Bind<IAgenteBiologicoService>().To<AgenteBiologicoService>();
            Bind<IMedicaoAgenteService>().To<MedicaoAgenteService>();
            Bind<IClassificacaoEfeitoService>().To<ClassificacaoEfeitoService>();
            Bind<IMeioPropagacaoService>().To<MeioPropagacaoService>();

            //Data Repository
            Bind<ITipoCursoRepository>().To<TipoCursoRepository>();
            Bind<ITipoExameRepository>().To<TipoExameRepository>();
            Bind<ITipoVacinaRepository>().To<TipoVacinaRepository>();
            Bind<ICursoRepository>().To<CursoRepository>();
            Bind<IExameRepository>().To<ExameRepository>();
            Bind<IVacinaRepository>().To<VacinaRepository>();
            Bind<IFuncionarioRepository>().To<FuncionarioRepository>();
            Bind<IAgenteErgonomicoRepository>().To<AgenteErgonomicoRepository>();
            Bind<ISetorRepository>().To<SetorRepository>();
            Bind<IAgenteAcidenteRepository>().To<AgenteAcidenteRepository>();
            Bind<IAgenteQuimicoRepository>().To<AgenteQuimicoRepository>();
            Bind<IAgenteFisicoRepository>().To<AgenteFisicoRepository>();
            Bind<IAgenteBiologicoRepository>().To<AgenteBiologicoRepository>();
            Bind<IMedicaoAgenteRepository>().To<MedicaoAgenteRepository>();
            Bind<IClassificacaoEfeitoRepositiry>().To<ClassificacaoEfeitoRepository>();
            Bind<IMeioPropagacaoRepository>().To<MeioPropagacaoRepository>();

            //Data Configuration
            Bind<IContextManager>().To<ContextManager>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
