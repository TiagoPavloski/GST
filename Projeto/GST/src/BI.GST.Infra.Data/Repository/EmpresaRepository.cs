using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using BI.GST.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Repository
{
	public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
	{
		public int ObterTotalRegistros(string pesquisa)
		{
			return DbSet.Count(x => (pesquisa != null ? x.NomeFantasia.Contains(pesquisa) : x.NomeFantasia != null) && (x.Delete == false));
		}

		public IEnumerable<Empresa> ObterGrid(int page, string pesquisa)
		{
			var empresaUtilizadora = new UsuarioRepository().ObterTodos().FirstOrDefault();

			return DbSet.Where(x => (pesquisa != null ? x.NomeFantasia.Contains(pesquisa) : x.NomeFantasia != null) && (x.Delete == false) && (x.EmpresaId != empresaUtilizadora.EmpresaId))
					   .OrderBy(u => u.NomeFantasia)
					   .Skip((page) * 10)
					   .Take(10);
		}

		public override void Adicionar(Empresa obj)
		{
			SetorRepository sr = new SetorRepository();
			CnaeRepository cr = new CnaeRepository();

			//Adiciona lista de cnae completa com o cnae Id que foi pego na tela
			List<Cnae> cnaes = new List<Cnae>();
			foreach (var item in obj.CnaeSecundarios)
				cnaes.Add(cr.ObterPorId(item.CnaeId));
			obj.CnaeSecundarios = cnaes;

			//Adiciona lista de setores completa com o setor id que foi pego na tela
			List<Setor> setores = new List<Setor>();
			foreach (var item in obj.Setores)
				setores.Add(sr.ObterPorId(item.SetorId));
			obj.Setores = setores;

			base.Adicionar(obj);

			//adiciona telefone cadastrado na tela na tabela telefone
			foreach (var item in obj.Telefones)
				new TelefoneRepository().Adicionar(item);
		}

		public override void Atualizar(Empresa obj)
		{
			SetorRepository st = new SetorRepository();
			CnaeRepository cr = new CnaeRepository();
			FileRepository file = new FileRepository();

			//Adiciona Objeto CnaePrincipal
			obj.CnaePrincipal = new CnaeRepository().ObterPorId(obj.CnaePrincipal.CnaeId);

			//Adiciona lista de cnae completa com o cnae Id que foi pego na tela
			List<Cnae> cnaes = new List<Cnae>();
			foreach (var item in obj.CnaeSecundarios)
			{
				cnaes.Add(cr.ObterPorId(item.CnaeId));
				item.Empresas.Add(obj);
			}
			obj.CnaeSecundarios = cnaes;

			//Adiciona lista de setores completa com o setor id que foi pego na tela
			List<Setor> setores = new List<Setor>();
			foreach (var item in obj.Setores)
			{
				setores.Add(st.ObterPorId(item.SetorId));
				item.Empresas.Add(obj);
			}
			obj.Setores = setores;

			if (obj.Files != null && obj.Files.Count > 0)
				obj.Files.FirstOrDefault().EmpresaId = obj.EmpresaId;

			//Atualiza tabela Empresasetor e CnaeSecundarioEmpresa
			using (var context = new ProjetoContext())
			{
				context.Database.ExecuteSqlCommand("delete empresasetor where Empresa_EmpresaId = " + obj.EmpresaId + "");
				context.Database.ExecuteSqlCommand("delete cnaeSecundarioEmpresa where EmpresaId = " + obj.EmpresaId + "");
				foreach (var item in setores)
					context.Database.ExecuteSqlCommand("insert into empresasetor values (" + obj.EmpresaId + ", " + item.SetorId + ")");
				foreach (var item in cnaes)
					context.Database.ExecuteSqlCommand("insert into CnaeSecundarioEmpresa values (" + obj.EmpresaId + ", " + item.CnaeId + ")");
			}

			base.Atualizar(obj);

			//Remove Imagem antiga e insere imagem nova
			if (obj.Files != null && obj.Files.Count > 0)
			{
				var imagem = file.Find(x => x.EmpresaId == obj.EmpresaId).FirstOrDefault();
				if (imagem != null)
					file.Excluir(file.Find(x => x.EmpresaId == obj.EmpresaId).FirstOrDefault().FileId);
				if (obj.Files.FirstOrDefault() != null)
					file.Adicionar(obj.Files.FirstOrDefault());
			}
			//Atualiza ou Insere Telefone
			foreach (var item in obj.Telefones)
			{
				if (item.TelefoneId == 0)
					new TelefoneRepository().Adicionar(item);
				else
					new TelefoneRepository().Atualizar(item);
			}

			//Atualiza Endereco
			new EnderecoRepository().Atualizar(obj.Endereco);
		}
	}
}
