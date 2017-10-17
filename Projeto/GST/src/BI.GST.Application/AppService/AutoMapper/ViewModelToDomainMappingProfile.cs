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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<TipoCursoViewModel, TipoCurso>();
            Mapper.CreateMap<TipoExameViewModel, TipoExame>();
            Mapper.CreateMap<TipoVacinaViewModel, TipoVacina>();
            Mapper.CreateMap<VacinaViewModel, Vacina>();
            Mapper.CreateMap<CursoViewModel, Curso>();
            Mapper.CreateMap<ExameViewModel, Exame>();
            Mapper.CreateMap<FuncionarioViewModel, Funcionario>();
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<TelefoneViewModel, Telefone>();
            Mapper.CreateMap<UFViewModel, UF>();
            Mapper.CreateMap<EnderecoViewModel, Endereco>();
            Mapper.CreateMap<AgenteAmbientalViewModel, AgenteAmbiental>();
            Mapper.CreateMap<EquipamentoRuidoViewModel, EquipamentoRuido>();
            Mapper.CreateMap<FinanceiroViewModel, Financeiro>();
            Mapper.CreateMap<AgenteErgonomicoViewModel, AgenteErgonomico>();
            Mapper.CreateMap<AgenteAcidenteViewModel, AgenteAcidente>();
            Mapper.CreateMap<SetorViewModel, Setor>();
            Mapper.CreateMap<AgenteQuimicoViewModel, AgenteQuimico>();
            Mapper.CreateMap<AgenteFisicoViewModel, AgenteFisico>();
            Mapper.CreateMap<AgenteBiologicoViewModel, AgenteBiologico>();
            Mapper.CreateMap<MedicaoAgenteViewModel, MedicaoAgente>();
            Mapper.CreateMap<ClassificacaoEfeitoViewModel, ClassificacaoEfeito>();
            Mapper.CreateMap<MeioPropagacaoViewModel, MeioPropagacao>();
            Mapper.CreateMap<CronogramaDeAcoesViewModel, CronogramaDeAcoes>();
            Mapper.CreateMap<AgentePPRAViewModel, AgentePPRA>();
            Mapper.CreateMap<EmpresaViewModel, Empresa>();
            Mapper.CreateMap<EscalaViewModel, Escala>();
            Mapper.CreateMap<AgenteCausadorCBOViewModel, AgenteCausadorCBO>();
            Mapper.CreateMap<AnexoViewModel, Anexo>();
			Mapper.CreateMap<CnaeViewModel, Cnae>();
            Mapper.CreateMap<PPRAViewModel, PPRA>();
            Mapper.CreateMap<CIPAEmpresaViewModel, CIPAEmpresa>();
            Mapper.CreateMap<CIPAEmpresaFuncionarioViewModel, CIPAEmpresaFuncionario>();
            Mapper.CreateMap<SESMTEmpresaViewModel, SESMTEmpresa>();
            Mapper.CreateMap<SESMTEmpresaFuncionarioViewModel, SESMTEmpresaFuncionario>();
            Mapper.CreateMap<FonteRiscoCBOViewModel, FonteRiscoCBO>();
            Mapper.CreateMap<GrupoCipaViewModel, GrupoCipa>();
			Mapper.CreateMap<OSViewModel, OS>();
			Mapper.CreateMap<ColaboradorViewModel, Colaborador>();
            Mapper.CreateMap<RiscoCBOViewModel, RiscoCBO>();
            Mapper.CreateMap<AgenteRiscoCBOViewModel, AgenteRiscoCBO>();
            Mapper.CreateMap<FuncionarioViewModel, Funcionario>();
            Mapper.CreateMap<CBOViewModel, CBO>();
            Mapper.CreateMap<FuncionarioEmpresaViewModel, FuncionarioEmpresa>();
            Mapper.CreateMap<FinanceiroParcelaViewModel, FinanceiroParcela>();
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
        }
	}
}
