﻿using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
	public class UsuariosController : Controller
	{
		private readonly IUsuarioAppService _usuarioAppService;
		private readonly ICursoAppService _cursoAppService;
		private readonly IExameAppService _exameAppService;
		private readonly IVacinaAppService _vacinaAppService;

		public UsuariosController(IUsuarioAppService usuarioAppService, ICursoAppService cursoAppService, IExameAppService exameAppService, IVacinaAppService vacinaAppService)
		{
			_usuarioAppService = usuarioAppService;
			_cursoAppService = cursoAppService;
			_exameAppService = exameAppService;
			_vacinaAppService = vacinaAppService;
		}

		// GET: Usuarios
		public ActionResult Index(string pesquisa, int page = 0)
		{
			if (Session["usuario"] == null)
				return RedirectToAction("Login", "Usuarios");
			var UsuarioViewModel = _usuarioAppService.ObterGrid(page, pesquisa);
			ViewBag.PaginaAtual = page;
			ViewBag.Busca = "&pesquisa=" + pesquisa;
			ViewBag.Controller = "Cursos";
			ViewBag.TotalRegistros = _usuarioAppService.ObterTotalRegistros(pesquisa);

			return View(UsuarioViewModel);
		}

		// GET: Usuarios/Details/5
		public ActionResult Details(int? id)
		{
			if (Session["usuario"] == null)
				return RedirectToAction("Login", "Usuarios");
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var Usuario = _usuarioAppService.ObterPorId(id.Value);
			if (Usuario == null)
			{
				return HttpNotFound();
			}
			return View(Usuario);
		}

		// GET: Usuarios/Create
		public ActionResult Create()
		{
			if (Session["usuario"] == null)
				return RedirectToAction("Login", "Usuarios");
			return View();
		}

		// POST: Usuarios/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(UsuarioViewModel UsuarioViewModel)
		{
			if (Session["usuario"] == null)
				return RedirectToAction("Login", "Usuarios");
			if (ModelState.IsValid)
			{
				if (!_usuarioAppService.Adicionar(UsuarioViewModel))
				{
					TempData["Mensagem"] = "Atenção, há um Usuario com os mesmos dados";
				}
				else
					return RedirectToAction("Index");
			}
			return View(UsuarioViewModel);
		}

		// GET: Usuarios/Edit/5
		public ActionResult Edit(int? id)
		{
			if (Session["usuario"] == null)
				return RedirectToAction("Login", "Usuarios");
			UsuarioViewModel usuario = null;
			if (id == null)
			{
				usuario = _usuarioAppService.ObterPorId((int)Session["usuarioId"]);
			}
			else
			{
				usuario = _usuarioAppService.ObterPorId(id.Value);
			}
			if (usuario == null)
			{
				return HttpNotFound();
			}
			return View(usuario);
		}

		// POST: Usuarios/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(UsuarioViewModel UsuarioViewModel)
		{
			if (Session["usuario"] == null)
				return RedirectToAction("Login", "Usuarios");
			if (ModelState.IsValid)
			{
				if (!_usuarioAppService.Atualizar(UsuarioViewModel))
				{
					TempData["Mensagem"] = "Atenção, há um tipo de Usuario com os mesmos dados já cadastrada";
				}
				else if (UsuarioViewModel.UsuarioId != (int)Session["usuarioId"])
					return RedirectToAction("Index");
				else
					return RedirectToAction("Index", "Home");
			}
			return View(UsuarioViewModel);
		}

		// GET: Usuarios/Delete/5
		public ActionResult Delete(int? id)
		{
			if (Session["usuario"] == null)
				return RedirectToAction("Login", "Usuarios");
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var Usuario = _usuarioAppService.ObterPorId(id.Value);
			if (Usuario == null)
			{
				return HttpNotFound();
			}
			return View(Usuario);
		}

		// POST: Usuarios/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			if (Session["usuario"] == null)
				return RedirectToAction("Login", "Usuarios");
			if (!_usuarioAppService.Excluir(id))
			{
				TempData["Mensagem"] = "Erro";
				return null;
			}
			else
			{
				return RedirectToAction("Index");
			}
		}

		// GET: Usuarios/Create
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(UsuarioViewModel usuarioViewModel)
		{
			var usuario = _usuarioAppService.Login(usuarioViewModel);

			if (usuario.UsuarioId != 0)
			{
				Session["usuario"] = usuario;
				Session["usuarioId"] = usuario.UsuarioId;
				Session["usuarioNome"] = usuario.Nome;
				//foreach (var item in usuario.Empresa.Files)
				//{
				//	Session["usuarioImg"] = item.FileId;
				//	break;
				//}
				return RedirectToAction("Index", "Home");
			}
			else
			{
				TempData["Mensagem"] = "Dados Incorretos, tente novamente";
				return View(usuarioViewModel);
			}
		}

		// GET: Usuarios/Edit/5
		public ActionResult EditEmpresa(int? id)
		{
			if (Session["usuario"] == null)
				return RedirectToAction("Login", "Usuarios");
			if (id.HasValue)
			{
				Session["actionUsuario"] = id.Value;
				return RedirectToAction("Edit", "Empresas", new { @id = id.Value });
			}
			else
			{
				TempData["Mensagem"] = "Empresa não encontrada";
				var usuario = _usuarioAppService.ObterPorId(id.Value);
				return View(usuario);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_usuarioAppService.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
