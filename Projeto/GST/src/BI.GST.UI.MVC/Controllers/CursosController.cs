using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
	public class CursosController : Controller
	{
		private readonly ICursoAppService _cursoAppService;
		private readonly ITipoCursoAppService _tipoCursoAppService;
		private readonly IFuncionarioAppService _funcionarioAppService;

		public CursosController(ICursoAppService cursoAppService, ITipoCursoAppService tipoCursoAppService, IFuncionarioAppService funcionarioAppService)
		{
			_cursoAppService = cursoAppService;
			_tipoCursoAppService = tipoCursoAppService;
			_funcionarioAppService = funcionarioAppService;
		}

		// GET: Cursos
		public ActionResult Index(string pesquisa, int page = 0)
		{
			var cursosViewModel = _cursoAppService.ObterGrid(page, pesquisa);
			ViewBag.PaginaAtual = page;
			ViewBag.Busca = "&pesquisa=" + pesquisa;
			ViewBag.Controller = "Cursos";
			ViewBag.TotalRegistros = _cursoAppService.ObterTotalRegistros(pesquisa);

			#region Alerta Cursos Vencidos
			string mensagem = null;
			var cursos = _cursoAppService.AlertaCursos();
			if (cursos != null)
			{
				string funcionarioCurso = "";
				foreach (var item in cursos)
				{
					funcionarioCurso += item.Funcionario.Nome + ", ";
				}
				mensagem += "* Os seguintes funcionarios estão com seus cursos vencidos: " + funcionarioCurso;
			}
			if (cursos != null && cursos.Count > 0)
			{
				mensagem = mensagem.Substring(0, mensagem.Length - 2);
				mensagem += ".";
				TempData["Mensagem"] = mensagem;
			}
			#endregion

			return View(cursosViewModel);
		}

		// GET: Cursos/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var curso = _cursoAppService.ObterPorId(id.Value);
			if (curso == null)
			{
				return HttpNotFound();
			}
			var ddlStatus_Cursos = (List<SelectListItem>)TempData["ddlStatus_Cursos"];
			return View(curso);
		}

		// GET: Cursos/Create
		public ActionResult Create()
		{
			ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome");
			ViewBag.TipoCursoId = new SelectList(_tipoCursoAppService.ObterTodos(), "TipoCursoId", "Nome");
			return View();
		}

		// POST: Cursos/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CursoViewModel cursoViewModel)
		{
			if (ModelState.IsValid)
			{
				if (!_cursoAppService.Adicionar(cursoViewModel))
				{
					TempData["Mensagem"] = "Atenção, há um Curso com os mesmos dados";
				}
				else
					return RedirectToAction("Index");
			}

			ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome", cursoViewModel.FuncionarioId);
			ViewBag.TipoCursoId = new SelectList(_tipoCursoAppService.ObterTodos(), "TipoCursoId", "Nome", cursoViewModel.TipoCursoId);
			return View(cursoViewModel);
		}

		// GET: Cursos/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var curso = _cursoAppService.ObterPorId(id.Value);
			if (curso == null)
			{
				return HttpNotFound();
			}
			ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome", curso.FuncionarioId);
			ViewBag.TipoCursoId = new SelectList(_tipoCursoAppService.ObterTodos(), "TipoCursoId", "Nome", curso.TipoCursoId);
			return View(curso);
		}

		// POST: Cursos/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(CursoViewModel cursoViewModel)
		{

			if (ModelState.IsValid)
			{
				if (!_cursoAppService.Atualizar(cursoViewModel))
				{
					TempData["Mensagem"] = "Atenção, há um Curso com os mesmos dados já cadastrada";
				}
				else
					return RedirectToAction("Index");
			}
			return View(cursoViewModel);
		}

		// GET: Cursos/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var curso = _cursoAppService.ObterPorId(id.Value);
			if (curso == null)
			{
				return HttpNotFound();
			}
			var ddlStatus_Cursos = (List<SelectListItem>)TempData["ddlStatus_Cursos"];
			return View(curso);
		}

		// POST: Cursos/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			if (!_cursoAppService.Excluir(id))
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
				_cursoAppService.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
