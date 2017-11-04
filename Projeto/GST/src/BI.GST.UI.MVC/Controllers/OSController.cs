using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using Rotativa.MVC;
using Rotativa.Core.Options;

namespace BI.GST.UI.MVC.Controllers
{
	public class OSController : Controller
	{
		private readonly IOSAppService _oSAppService;
		private readonly IFuncionarioAppService _funcionarioAppService;

		public OSController(IOSAppService oSAppService, IFuncionarioAppService funcionarioAppService)
		{
			_oSAppService = oSAppService;
			_funcionarioAppService = funcionarioAppService;
		}
		// GET: OS
		public ActionResult Index(string pesquisa, int page = 0)
		{
			var osViewModel = _oSAppService.ObterGrid(page, pesquisa);
			ViewBag.PaginaAtual = page;
			ViewBag.Busca = "&pesquisa=" + pesquisa;
			ViewBag.Controller = "OS";
			ViewBag.TotalRegistros = _oSAppService.ObterTotalRegistros(pesquisa);

			return View(osViewModel);

		}

		// GET: OS/Create
		public ActionResult Create()
		{
			ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome");
			return View();
		}

		// POST: OS/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(OSViewModel oSViewModel)
		{
			if (ModelState.IsValid)
			{
				if (!_oSAppService.Adicionar(oSViewModel))
				{
					TempData["Mensagem"] = "Erro";
				}
				else
					return RedirectToAction("Index");
			}
			ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome");
			return View(oSViewModel);
		}

		// GET: OS/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var oS = _oSAppService.ObterPorId(id.Value);
			if (oS == null)
			{
				return HttpNotFound();
			}
			ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome");
			return View(oS);
		}

		// POST: OS/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(OSViewModel oS)
		{
			if (ModelState.IsValid)
			{
				if (!_oSAppService.Atualizar(oS))
				{
					TempData["Mensagem"] = "Erro";
				}
				else
					return RedirectToAction("Index");
			}
			ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome");
			return View(oS);
		}

		// GET: OS/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var oS = _oSAppService.ObterPorId(id.Value);
			if (oS == null)
			{
				return HttpNotFound();
			}
			return View(oS);
		}

		// POST: OS/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			if (!_oSAppService.Excluir(id))
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
				_oSAppService.Dispose();
			}
			base.Dispose(disposing);
		}

		public ActionResult Gerar(int? id)
		{
			var oS = _oSAppService.ObterPorId(id.Value);

			var pdf = new ViewAsPdf
			{
				ViewName = "Gerar",
				Model = oS
			};

			return pdf;
		}
	}
}
