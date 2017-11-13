using AutoMapper;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<TipoCurso, TipoCursoViewModel>();
            Mapper.CreateMap<TipoExame, TipoExameViewModel>();
            Mapper.CreateMap<TipoVacina, TipoVacinaViewModel>();
            Mapper.CreateMap<Vacina, VacinaViewModel>();
            Mapper.CreateMap<Curso, CursoViewModel>();
            Mapper.CreateMap<Exame, ExameViewModel>();
            Mapper.CreateMap<Pessoa, PessoaViewModel>();
            Mapper.CreateMap<Funcionario, FuncionarioViewModel>();
			Mapper.CreateMap<Telefone, TelefoneViewModel>();
			Mapper.CreateMap<UF, UFViewModel>();
			Mapper.CreateMap<Endereco, EnderecoViewModel>();
            Mapper.CreateMap<EquipamentoRuido, EquipamentoRuidoViewModel>();
            Mapper.CreateMap<Financeiro, FinanceiroViewModel>();
            Mapper.CreateMap<AgenteAmbiental, AgenteAmbientalViewModel>();
			Mapper.CreateMap<Empresa, EmpresaViewModel>();
            Mapper.CreateMap<Escala, EscalaViewModel>();
            Mapper.CreateMap<AgenteCausadorCBO, AgenteCausadorCBOViewModel>();
            Mapper.CreateMap<FonteRiscoCBO, FonteRiscoCBOViewModel>();
            Mapper.CreateMap<AgenteErgonomico, AgenteErgonomicoViewModel>();
            Mapper.CreateMap<AgenteAcidente, AgenteAcidenteViewModel>();
            Mapper.CreateMap<Setor, SetorViewModel>();
            Mapper.CreateMap<AgenteQuimico, AgenteQuimicoViewModel>();
            Mapper.CreateMap<AgenteFisico, AgenteFisicoViewModel>();
            Mapper.CreateMap<AgenteBiologico, AgenteBiologicoViewModel>();
            Mapper.CreateMap<MedicaoAgente, MedicaoAgenteViewModel>();
            Mapper.CreateMap<ClassificacaoEfeito, ClassificacaoEfeitoViewModel>();
            Mapper.CreateMap<MeioPropagacao, MeioPropagacaoViewModel>();
            Mapper.CreateMap<AgentePPRA, AgentePPRAViewModel>();
            Mapper.CreateMap<CronogramaDeAcoes, CronogramaDeAcoesViewModel>();
            Mapper.CreateMap<Anexo, AnexoViewModel>();
            Mapper.CreateMap<PPRA, PPRAViewModel>();
            Mapper.CreateMap<CIPAEmpresa, CIPAEmpresaViewModel>();
            Mapper.CreateMap<CIPAEmpresaFuncionario, CIPAEmpresaFuncionarioViewModel>();
            Mapper.CreateMap<SESMTEmpresa, SESMTEmpresaViewModel>();
            Mapper.CreateMap<SESMTEmpresaFuncionario, SESMTEmpresaFuncionarioViewModel>();
            Mapper.CreateMap<GrupoCipa, GrupoCipaViewModel>();
			Mapper.CreateMap<Cnae, CnaeViewModel>();
			Mapper.CreateMap<OS, OSViewModel>();
			Mapper.CreateMap<Colaborador, ColaboradorViewModel>();
            Mapper.CreateMap<RiscoCBO, RiscoCBOViewModel>();
            Mapper.CreateMap<RiscoFuncionario, RiscoFuncionarioViewModel>();
            Mapper.CreateMap<AgenteRiscoCBO, AgenteRiscoCBOViewModel>();
            Mapper.CreateMap<CBO, CBOViewModel>();
            Mapper.CreateMap<FuncionarioEmpresa, FuncionarioEmpresaViewModel>();
            Mapper.CreateMap<InstituicaoCurso, InstituicaoCursoViewModel>();
            Mapper.CreateMap<Certificado, CertificadoViewModel>();
            Mapper.CreateMap<EPI, EPIViewModel>();
			Mapper.CreateMap<Usuario, UsuarioViewModel>();
			Mapper.CreateMap<FinanceiroParcela, FinanceiroParcelaViewModel>();
            Mapper.CreateMap<TipoSetor, TipoSetorViewModel>();
            Mapper.CreateMap<CipaQuadro, CipaQuadroViewModel>();
            Mapper.CreateMap<SesmtQuadro, SesmtQuadroViewModel>();
			Mapper.CreateMap<File, FileViewModel>();
			Mapper.CreateMap<FileType, FileTypeViewModel>();
		}
	}
}

