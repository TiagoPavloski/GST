using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
	public class EmpresasController : Controller
	{

		private readonly IEmpresaAppService _empresaAppService;
		private readonly IEnderecoAppService _enderecoAppService;
		private readonly ITelefoneAppService _telefoneAppService;
		private readonly ICnaeAppService _cnaeAppService;
		private readonly ISetorAppService _setorAppService;
		private readonly IUFAppService _uFAppService;
		//private readonly IFuncionarioAppService _funcionarioAppService;

		public EmpresasController(IEmpresaAppService empresaAppService, IEnderecoAppService enderecoAppService, ITelefoneAppService telefoneAppService, ICnaeAppService cnaeAppService, ISetorAppService setorAppService, IUFAppService uFAppService/*, IFuncionarioAppService funcionarioAppService*/)
		{
			_empresaAppService = empresaAppService;
			_enderecoAppService = enderecoAppService;
			_telefoneAppService = telefoneAppService;
			_cnaeAppService = cnaeAppService;
			_setorAppService = setorAppService;
			_uFAppService = uFAppService;
			/*_funcionarioAppService = funcionarioAppService;*/
		}
		// GET: Empresas
		public ActionResult Index(string pesquisa, int page = 0)
		{
			var empresaViewModel = _empresaAppService.ObterGrid(page, pesquisa);
			ViewBag.PaginaAtual = page;
			ViewBag.Busca = "&pesquisa=" + pesquisa;
			ViewBag.Controller = "Empresas";
			ViewBag.TotalRegistros = _empresaAppService.ObterTotalRegistros(pesquisa);

			return View(empresaViewModel);
		}

		// GET: Empresas/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var empresa = _empresaAppService.ObterPorId(id.Value);
			if (empresa == null)
			{
				return HttpNotFound();
			}
			return View(empresa);
		}

		public ActionResult LinhaTelefone()
		{
			var telefone = new TelefoneViewModel();
			return PartialView("_Telefone", telefone);
		}

		// GET: Empresas/Create
		public ActionResult Create()
		{
			ViewBag.UFId = new SelectList(_uFAppService.ObterTodos(), "UFId", "Nome");
			ViewBag.CnaeIdList = new MultiSelectList(_cnaeAppService.ObterTodos(), "CnaeId", "Descricao");
			ViewBag.CnaeId = ViewBag.CnaeIdList;
			ViewBag.SetorIdList = new MultiSelectList(_setorAppService.ObterTodos(), "SetorId", "Nome");
			/*ViewBag.FuncionarioIdList = new MultiSelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome");*/

			var empresaViewModel = new EmpresaViewModel();
			return View(empresaViewModel);
		}

		// POST: Empresas/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(EmpresaViewModel empresaViewModel, List<TelefoneViewModel> telefoneViewModel, int[] setorId, int[] cnaeSecundarioId/*, int[] funcionarioId*/)
		{
			if (ModelState.IsValid)
			{
				if (!_empresaAppService.Adicionar(empresaViewModel, telefoneViewModel, setorId, cnaeSecundarioId/*, funcionarioId*/))
				{
					TempData["Mensagem"] = "Atenção, há um empresa com os mesmos dados";
				}
				else
					return RedirectToAction("Index");
			}
			return View(empresaViewModel);
		}

		// GET: Empresas/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var empresa = _empresaAppService.ObterPorId(id.Value);
			if (empresa == null)
			{
				return HttpNotFound();
			}

			ViewBag.UFId = new SelectList(_uFAppService.ObterTodos(), "UFId", "Nome", empresa.Endereco.UF.UFId);
			ViewBag.CnaeIdList = new MultiSelectList(_cnaeAppService.ObterTodos(), "CnaeId", "Descricao", empresa.CnaeSecundarios.Select(x => x.CnaeId));
			ViewBag.CnaeId = new SelectList(_cnaeAppService.ObterTodos(), "CnaeId", "Descricao", empresa.CnaePrincipal.CnaeId);
			ViewBag.SetorIdList = new MultiSelectList(_setorAppService.ObterTodos(), "SetorId", "Nome", empresa.Setores.Select(x => x.SetorId));
			/*ViewBag.FuncionarioIdList = new MultiSelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome", empresa.Responsaveis.Select(x => x.FuncionarioId));*/

			return View(empresa);
		}

		// POST: Empresas/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(EmpresaViewModel empresaViewModel, List<TelefoneViewModel> telefoneViewModel, int[] setorId, int[] cnaeSecundarioId)
		{
			//if (ModelState.IsValid)
			//{
			if (!_empresaAppService.Atualizar(empresaViewModel, telefoneViewModel, setorId, cnaeSecundarioId))
			{
				TempData["Mensagem"] = "Atenção, há um tipo de Curso com os mesmos dados já cadastrada";
				return View(empresaViewModel);
			}
			if (Session["actionUsuario"] != null)
			{
				Session["actionUsuario"] = null;
				return RedirectToAction("Edit", "Usuarios");
			}
			return RedirectToAction("Index");
			//}
			//return View(empresaViewModel);
		}

		// GET: Empresas/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var empresa = _empresaAppService.ObterPorId(id.Value);
			if (empresa == null)
			{
				return HttpNotFound();
			}
			return View(empresa);
		}

		// POST: Empresas/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			if (!_empresaAppService.Excluir(id))
			{
				TempData["Mensagem"] = "Erro";
				return null;
			}
			else
			{
				return RedirectToAction("Index");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_empresaAppService.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
