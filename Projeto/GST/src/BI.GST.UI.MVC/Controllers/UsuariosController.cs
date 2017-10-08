using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BI.GST.Domain.Entities;
using BI.GST.Infra.Data.Context;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
	public class UsuariosController : Controller
	{
		private readonly IUsuarioAppService _UsuarioAppService;


		public UsuariosController(IUsuarioAppService UsuarioAppService)
		{
			_UsuarioAppService = UsuarioAppService;
		}

		// GET: Usuarios
		public ActionResult Index(string pesquisa, int page = 0)
		{
			var UsuarioViewModel = _UsuarioAppService.ObterGrid(page, pesquisa);
			ViewBag.PaginaAtual = page;
			ViewBag.Busca = "&pesquisa=" + pesquisa;
			ViewBag.Controller = "Cursos";
			ViewBag.TotalRegistros = _UsuarioAppService.ObterTotalRegistros(pesquisa);

			return View(UsuarioViewModel);
		}

		// GET: Usuarios/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var Usuario = _UsuarioAppService.ObterPorId(id.Value);
			if (Usuario == null)
			{
				return HttpNotFound();
			}
			return View(Usuario);
		}

		// GET: Usuarios/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Usuarios/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(UsuarioViewModel UsuarioViewModel)
		{
			if (ModelState.IsValid)
			{
				if (!_UsuarioAppService.Adicionar(UsuarioViewModel))
				{
					System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Usuario com os mesmos dados')</SCRIPT>");
				}
				else
					return RedirectToAction("Index");
			}
			return View(UsuarioViewModel);
		}

		// GET: Usuarios/Edit/5
		public ActionResult Edit(int? id)
		{
			UsuarioViewModel usuario = null;
			if (id == null)
			{
				usuario = _UsuarioAppService.ObterPorId((int)Session["usuarioId"]);
			}
			else
			{
				usuario = _UsuarioAppService.ObterPorId(id.Value);
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
			if (ModelState.IsValid)
			{
				if (!_UsuarioAppService.Atualizar(UsuarioViewModel))
				{
					System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipo de Usuario com os mesmos dados já cadastrada')</SCRIPT>");
				}
				else if(UsuarioViewModel.UsuarioId != (int)Session["usuarioId"])
					return RedirectToAction("Index");
				else
					return RedirectToAction("Index", "Home");
			}
			return View(UsuarioViewModel);
		}

		// GET: Usuarios/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var Usuario = _UsuarioAppService.ObterPorId(id.Value);
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
			if (!_UsuarioAppService.Excluir(id))
			{
				System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Erro')</SCRIPT>");
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
			var usuario = _UsuarioAppService.Login(usuarioViewModel);

			if (usuario.UsuarioId != 0)
			{
				Session["usuario"] = usuario;
				Session["usuarioId"] = usuario.UsuarioId;
				return RedirectToAction("Index", "Home");
			}
			else
			{
				System.Web.HttpContext.Current.Response.Write("<SCRIPT> Dados Incorretos, tente novamente.</SCRIPT>");
				return View(usuarioViewModel);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_UsuarioAppService.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
