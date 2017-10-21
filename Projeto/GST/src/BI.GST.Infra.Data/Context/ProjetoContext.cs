using BI.GST.Domain.Entities;
using BI.GST.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Context
{
	public class ProjetoContext : DbContext
	{
		public ProjetoContext()
			: base("ProjetoContext")
		{
			//Database.SetInitializer<ProjetoContext>(new ProjetoContextInitializer());
		}

		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<EnderecoEx> EnderecosEx { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<AgenteAcidente> AgentesAcidente { get; set; }
		public DbSet<AgenteAmbiental> AgentesAmbiental { get; set; }
		public DbSet<AgenteBiologico> AgentesBiologico { get; set; }
		public DbSet<AgenteCausadorCBO> AgentesCausadorCBO { get; set; }
		public DbSet<AgenteErgonomico> AgentesErgonomico { get; set; }
		public DbSet<AgenteFisico> AgentesFisico { get; set; }
		public DbSet<AgentePPRA> AgentesPPRA { get; set; }
		public DbSet<AgenteQuimico> AgentseQuimico { get; set; }
		public DbSet<AgenteRiscoCBO> AgentesRiscoCBO { get; set; }
		public DbSet<Anexo> Anexos { get; set; }
		public DbSet<CBO> CBOs { get; set; }
		public DbSet<Certificado> Certificados { get; set; }
		public DbSet<ClassificacaoEfeito> ClassificacoesEfeito { get; set; }
		public DbSet<Cnae> Cnaes { get; set; }
		public DbSet<Colaborador> Colaboradores { get; set; }
		public DbSet<CronogramaDeAcoes> CronogramasDeAcoes { get; set; }
		public DbSet<Curso> Cursos { get; set; }
		public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EPI> EPIs { get; set; }
        public DbSet<Usuario> EmpresasUtilizadora { get; set; }
		public DbSet<EquipamentoRuido> EquipamentosRuido { get; set; }
		public DbSet<Escala> Escalas { get; set; }
		public DbSet<Exame> Exames { get; set; }
		public DbSet<Financeiro> Financeiros { get; set; }
		public DbSet<FonteRiscoCBO> FontesRiscoCBO { get; set; }
		public DbSet<Funcionario> Funcionarios { get; set; }
		public DbSet<FuncionarioEmpresa> FuncionariosEmpresas { get; set; }
		public DbSet<InstituicaoCurso> InstituicoesCurso { get; set; }
		public DbSet<MedicaoAgente> MedicoesAgente { get; set; }
		public DbSet<MeioPropagacao> MeiosPropagacao { get; set; }
		public DbSet<OS> OSs { get; set; }
		public DbSet<PPRA> PPRAs { get; set; }
		public DbSet<RiscoCBO> RiscosCBO { get; set; }
		public DbSet<RiscoFuncionario> RiscosFuncionario { get; set; }
		public DbSet<Setor> Setores { get; set; }
		public DbSet<Telefone> Telefones { get; set; }
		public DbSet<TipoCurso> TiposCurso { get; set; }
		public DbSet<TipoExame> TiposExame { get; set; }
		public DbSet<TipoSetor> TiposSetor { get; set; }
		public DbSet<TipoVacina> TiposVacina { get; set; }
		public DbSet<UF> UFs { get; set; }
		public DbSet<Vacina> Vacinas { get; set; }
		public DbSet<CIPAEmpresa> CIPAEmpresas { get; set; }
		public DbSet<CIPAEmpresaFuncionario> CIPAEmpresaFuncionarios { get; set; }
		public DbSet<SESMTEmpresa> SESMTEmpresas { get; set; }
		public DbSet<SESMTEmpresaFuncionario> SESMTEmpresaFuncionarios { get; set; }
        public DbSet<CipaQuadro> CipaQuadro { get; set; }
        public DbSet<SesmtQuadro> SesmtQuadro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Convenções
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //tira pluralização
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //não excluir e cascata
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); //não excluir e cascata

            //Customizações gerais
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id") //Quando a propriedade tiver "Id" no final é setado como chave primaria
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
               .Configure(p => p.HasColumnType("varchar")); //Quando a propriedade for string é convertida pra varchar

            modelBuilder.Properties<string>()
              .Configure(p => p.HasMaxLength(100));

            //Mapeando configurações especificas
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new EnderecoExConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new AgenteAcidenteConfiguration());
            modelBuilder.Configurations.Add(new AgenteAmbientalConfiguration());
            modelBuilder.Configurations.Add(new AgenteBiologicoConfiguration());
            modelBuilder.Configurations.Add(new AgenteCausadorCBOConfiguration());
            modelBuilder.Configurations.Add(new AgenteErgonomicoConfiguration());
            modelBuilder.Configurations.Add(new AgenteFisicoConfiguration());
            modelBuilder.Configurations.Add(new AgentePPRAConfiguration());
            modelBuilder.Configurations.Add(new AgenteQuimicoConfiguration());
            modelBuilder.Configurations.Add(new AgenteRiscoCBOConfiguration());
            modelBuilder.Configurations.Add(new AnexoConfiguration());
            modelBuilder.Configurations.Add(new CBOConfiguration());
            modelBuilder.Configurations.Add(new CertificadoConfiguration());
            modelBuilder.Configurations.Add(new ClassificacaoEfeitoConfiguration());
            modelBuilder.Configurations.Add(new CnaeConfiguration());
            modelBuilder.Configurations.Add(new ColaboradorConfiguration());
            modelBuilder.Configurations.Add(new CronogramaDeAcoesConfiguration());
            modelBuilder.Configurations.Add(new CursoConfiguration());
            modelBuilder.Configurations.Add(new EmpresaConfiguration());
            modelBuilder.Configurations.Add(new EPIConfiguration());
            modelBuilder.Configurations.Add(new EquipamentoRuidoConfiguration());
            modelBuilder.Configurations.Add(new EscalaConfiguration());
            modelBuilder.Configurations.Add(new ExameConfiguration());
            modelBuilder.Configurations.Add(new FinanceiroConfiguration());
            modelBuilder.Configurations.Add(new FonteRiscoCBOConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioEmpresaConfiguration());
            modelBuilder.Configurations.Add(new InstituicaoCursoConfiguration());
            modelBuilder.Configurations.Add(new MedicaoAgenteConfiguration());
            modelBuilder.Configurations.Add(new MeioPropagacaoConfiguration());
            modelBuilder.Configurations.Add(new OSConfiguration());
            modelBuilder.Configurations.Add(new PPRAConfiguration());
            modelBuilder.Configurations.Add(new RiscoCBOConfiguration());
            modelBuilder.Configurations.Add(new RiscoFuncionarioConfiguration());
            modelBuilder.Configurations.Add(new SetorConfiguration());
            modelBuilder.Configurations.Add(new TelefoneConfiguration());
            modelBuilder.Configurations.Add(new TipoCursoConfiguration());
            modelBuilder.Configurations.Add(new TipoExameConfiguration());
            modelBuilder.Configurations.Add(new TipoSetorConfiguration());
            modelBuilder.Configurations.Add(new TipoVacinaConfiguration());
            modelBuilder.Configurations.Add(new UFConfiguration());
            modelBuilder.Configurations.Add(new VacinaConfiguration());
            modelBuilder.Configurations.Add(new CIPAEmpresaConfiguration());
            modelBuilder.Configurations.Add(new CipaEmpresaFuncionarioConfiguration());
            modelBuilder.Configurations.Add(new SESMTEmpresaConfiguration());
            modelBuilder.Configurations.Add(new SESMTEmpresaFuncionarioConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries().Where(Entry => Entry.Entity.GetType().GetProperty("DataCadastro") != null))
			{
				if (entry.State == EntityState.Added)
				{
					entry.Property("DataCadastro").CurrentValue = DateTime.Now; //Propriedade DataCadastro sempre recebe data Atual
				}
				if (entry.State == EntityState.Modified)
				{
					entry.Property("DataCadastro").IsModified = false; //Caso seja update não modifica
				}
			}
			foreach (var entry in ChangeTracker.Entries().Where(Entry => Entry.Entity.GetType().GetProperty("Delete") != null))
			{
				if (entry.State == EntityState.Added)
				{
					entry.Property("Delete").CurrentValue = false;
				}
			}

			//return base.SaveChanges();
			try
			{
				return base.SaveChanges();
			}

			catch (DbEntityValidationException e)
			{
				foreach (var eve in e.EntityValidationErrors)
				{
					Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
							ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
		}
	}
}
