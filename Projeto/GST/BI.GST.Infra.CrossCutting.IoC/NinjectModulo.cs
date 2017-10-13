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
        	Bind<IFinanceiroAppService>().To<FinanceiroAppService>();
        	Bind<IAgenteAmbientalAppService>().To<AgenteAmbientalAppService>();
        	Bind<IEquipamentoRuidoAppService>().To<EquipamentoRuidoAppService>();
            Bind<IAgenteErgonomicoAppService>().To<AgenteErgonomicoAppService>();
            Bind<ISetorAppService>().To<SetorAppService>();
            Bind<IAgenteAcidenteAppService>().To<AgenteAcidenteAppService>();
            Bind<IAgenteQuimicoAppService>().To<AgenteQuimicoAppService>();
            Bind<IAgenteFisicoAppService>().To<AgenteFisicoAppService>();
            Bind<IAgenteBiologicoAppService>().To<AgenteBiologicoAppService>();
            Bind<IMedicaoAgenteAppService>().To<MedicaoAgenteAppService>();
            Bind<IClassificacaoEfeitoAppService>().To<ClassificacaoEfeitoAppService>();
            Bind<IMeioPropagacaoAppService>().To<MeioPropagacaoAppService>();
            Bind<ICronogramaDeAcoesAppService>().To<CronogramaDeAcoesAppService>();
            Bind<IAgentePPRAAppService>().To<AgentePPRAAppService>();
			Bind<ICnaeAppService>().To<CnaeAppService>();
			Bind<IEmpresaAppService>().To<EmpresaAppService>();
            Bind<IEscalaAppService>().To<EscalaAppService>();
            Bind<IAgenteCausadorCBOAppService>().To<AgenteCausadorCBOAppService>();
            Bind<IAnexoAppService>().To<AnexoAppService>();
            Bind<IAgenteRiscoCBOAppService>().To<AgenteRiscoCBOAppService>();
			Bind<IPPRAAppService>().To<PPRAAppService>();
			Bind<ISESMTEmpresaAppService>().To<SESMTEmpresaAppService>();
			Bind<ISESMTEmpresaFuncionarioAppService>().To<SESMTEmpresaFuncionarioAppService>();
			Bind<ICIPAEmpresaAppService>().To<CIPAEmpresaAppService>();
			Bind<ICIPAEmpresaFuncionarioAppService>().To<CIPAEmpresaFuncionarioAppService>();
            Bind<IGrupoCipaAppService>().To<GrupoCipaAppService>();
			Bind<IFonteRiscoCBOAppService>().To<FonteRiscoCBOAppService>();
			Bind<IOSAppService>().To<OSAppService>();

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
        	Bind<IFinanceiroService>().To<FinanceiroService>();
        	Bind<IAgenteAmbientalService>().To<AgenteAmbientalService>();
        	Bind<IEquipamentoRuidoService>().To<EquipamentoRuidoService>();
            Bind<IAgenteErgonomicoService>().To<AgenteErgonomicoService>();
            Bind<ISetorService>().To<SetorService>();
            Bind<IAgenteAcidenteService>().To<AgenteAcidenteService>();
            Bind<IAgenteQuimicoService>().To<AgenteQuimicoService>();
            Bind<IAgenteFisicoService>().To<AgenteFisicoService>();
            Bind<IAgenteBiologicoService>().To<AgenteBiologicoService>();
            Bind<IMedicaoAgenteService>().To<MedicaoAgenteService>();
            Bind<IClassificacaoEfeitoService>().To<ClassificacaoEfeitoService>();
            Bind<IMeioPropagacaoService>().To<MeioPropagacaoService>();
            Bind<ICronogramaDeAcoesService>().To<CronogramaDeAcoesService>();
            Bind<IAgentePPRAService>().To<AgentePPRAService>();
			Bind<ICnaeService>().To<CnaeService>();
			Bind<IEmpresaService>().To<EmpresaService>();
            Bind<IEscalaService>().To<EscalaService>();
            Bind<IAgenteCausadorCBOService>().To<AgenteCausadorCBOService>();
            Bind<IAnexoService>().To<AnexoService>();
			Bind<IPPRAService>().To<PPRAService>();
			Bind<ICIPAEmpresaService>().To<CIPAEmpresaService>();
			Bind<ICIPAEmpresaFuncionarioService>().To<CIPAEmpresaFuncionarioService>();
			Bind<ISESMTEmpresaService>().To<SESMTEmpresaService>();
			Bind<ISESMTEmpresaFuncionarioService>().To<SESMTEmpresaFuncionarioService>();
            Bind<IAgenteRiscoCBOService>().To<AgenteRiscoCBOService>();
            Bind<IFonteRiscoCBOService>().To<FonteRiscoCBOService>();
            Bind<IGrupoCipaService>().To<GrupoCipaService>();
            Bind<ICipaQuadroService>().To<CipaQuadroService>();
            Bind<ISesmtQuadroService>().To<SesmtQuadroService>();
			Bind<IOSService>().To<OSService>();

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
  			Bind<IFinanceiroRepository>().To<FinanceiroRepository>();
        	Bind<IAgenteAmbientalRepository>().To<AgenteAmbientalRepository>();
        	Bind<IEquipamentoRuidoRepository>().To<EquipamentoRuidoRepository>();
            Bind<IAgenteErgonomicoRepository>().To<AgenteErgonomicoRepository>();
            Bind<ISetorRepository>().To<SetorRepository>();
            Bind<IAgenteAcidenteRepository>().To<AgenteAcidenteRepository>();
            Bind<IAgenteQuimicoRepository>().To<AgenteQuimicoRepository>();
            Bind<IAgenteFisicoRepository>().To<AgenteFisicoRepository>();
            Bind<IAgenteBiologicoRepository>().To<AgenteBiologicoRepository>();
            Bind<IMedicaoAgenteRepository>().To<MedicaoAgenteRepository>();
            Bind<IClassificacaoEfeitoRepositiry>().To<ClassificacaoEfeitoRepository>();
            Bind<IMeioPropagacaoRepository>().To<MeioPropagacaoRepository>();
            Bind<ICronogramaDeAcoesRepository>().To<CronogramaDeAcoesRepository>();
            Bind<IAgentePPRARepository>().To<AgentePPRARepository>();
			Bind<ICnaeRepository>().To<CnaeRepository>();
			Bind<IEmpresaRepository>().To<EmpresaRepository>();
            Bind<IEscalaRepository>().To<EscalaRepository>();
            Bind<IAgenteCausadorCBORepository>().To<AgenteCausadorCBORepository>();
            Bind<IAnexoRepository>().To<AnexoRepository>();
			Bind<IPPRARepository>().To<PPRARepository>();
            Bind<IAgenteRiscoCBORepository>().To<AgenteRiscoCBORepository>();
			Bind<ICIPAEmpresaRepository>().To<CIPAEmpresaRepository>();
			Bind<ICIPAEmpresaFuncionarioRepository>().To<CIPAEmpresaFuncionarioRepository>();
			Bind<ISESMTEmpresaRepository>().To<SESMTEmpresaRepository>();
			Bind<ISESMTEmpresaFuncionarioRepository>().To<SESMTEmpresaFuncionarioRepository>();
            Bind<IFonteRiscoCBORepository>().To<FonteRiscoCBORepository>();
            Bind<IGrupoCipaRepository>().To<GrupoCipaRepository>();
            Bind<ICipaQuadroRepository>().To<CipaQuadroRepository>();
            Bind<ISesmtQuadroRepository>().To<SesmtQuadroRepository>();
			Bind<IOSRepository>().To<OSRepository>();


			//Data Configuration
			Bind<IContextManager>().To<ContextManager>();
			Bind<IUnitOfWork>().To<UnitOfWork>();
		}
	}
}
