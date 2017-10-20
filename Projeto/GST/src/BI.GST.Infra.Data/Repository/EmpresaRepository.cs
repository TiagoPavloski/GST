using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
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
			return DbSet.Where(x => (pesquisa != null ? x.NomeFantasia.Contains(pesquisa) : x.NomeFantasia != null) && (x.Delete == false))
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

			base.Atualizar(obj);

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

		public void RemoverListas(int idEmpresa)
		{
			var empresa = base.ObterPorId(idEmpresa);
			empresa.CnaeSecundarios.Clear();
			empresa.Setores.Clear();

			var entry = Context.Entry(empresa);
			DbSet.Attach(empresa);
			entry.State = EntityState.Modified;
			base.SaveChanges();
		}
	}
}
