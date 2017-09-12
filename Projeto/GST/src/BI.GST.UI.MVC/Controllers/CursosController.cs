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
  public class CursosController : Controller
  {
    private readonly ICursoAppService _cursoAppService;
    private readonly ITipoCursoAppService _tipoCursoAppService;

    public CursosController(ICursoAppService cursoAppService, ITipoCursoAppService tipoCursoAppService)
    {
      _cursoAppService = cursoAppService;
      _tipoCursoAppService = tipoCursoAppService;
    }

    // GET: Cursos
    public ActionResult Index(string pesquisa, int page = 0)
    {
      var cursosViewModel = _cursoAppService.ObterGrid(page, pesquisa);
      //var cursos = db.Cursos.Include(c => c.Funcionario).Include(c => c.TipoCurso);
      ViewBag.PaginaAtual = page;
      ViewBag.Pesquisa = pesquisa;
      ViewBag.Controller = "Cursos";
      ViewBag.TotalRegistros = _cursoAppService.ObterTotalRegistros(pesquisa);

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
      return View(curso);
    }

    // GET: Cursos/Create
    public ActionResult Create()
    {
      // ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "PIS");
      //ViewBag.TipoCursoId = new SelectList(db.TiposCurso, "TipoCursoId", "Nome");
      List<FuncionarioViewModel> func = new List<FuncionarioViewModel>();
      CursoViewModel cursoViewModel = new CursoViewModel();
      ViewBag.FuncionarioId = new SelectList(func, "FuncionarioId", "PIS", cursoViewModel.FuncionarioId);
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
          System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Curso com os mesmos dados')</SCRIPT>");
        }
        else
          return RedirectToAction("Index");
      }

      //ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "PIS", curso.FuncionarioId);
      List<FuncionarioViewModel> func = new List<FuncionarioViewModel>();
      ViewBag.FuncionarioId = new SelectList(func, "FuncionarioId", "PIS", cursoViewModel.FuncionarioId);
      ViewBag.TipoCursoId = new SelectList(_tipoCursoAppService.ObterTodos(), "TipoCursoId", "Nome");
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
      // ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "PIS", curso.FuncionarioId);
      //  ViewBag.TipoCursoId = new SelectList(db.TiposCurso, "TipoCursoId", "Nome", curso.TipoCursoId);
      List<FuncionarioViewModel> func = new List<FuncionarioViewModel>(); 
      ViewBag.FuncionarioId = new SelectList(func, "FuncionarioId", "PIS", curso.FuncionarioId);
      ViewBag.TipoCursoId = new SelectList(_tipoCursoAppService.ObterTodos(), "TipoCursoId", "Nome");
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
          System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Curso com os mesmos dados já cadastrada')</SCRIPT>");
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
      return View(curso);
    }

    // POST: Cursos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      if (!_cursoAppService.Excluir(id))
      {
        System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Erro')</SCRIPT>");
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
