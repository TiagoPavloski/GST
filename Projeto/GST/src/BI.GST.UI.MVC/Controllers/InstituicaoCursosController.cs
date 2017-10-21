using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BI.GST.Domain.Entities;
using BI.GST.Infra.Data.Context;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
    public class InstituicaoCursosController : Controller
    {
        private readonly IInstituicaoCursoAppService _instituicaoCursoAppService;

        public InstituicaoCursosController(IInstituicaoCursoAppService instituicaoCursoAppService)
        {
            _instituicaoCursoAppService = instituicaoCursoAppService;
        }

        // GET: InstituicaoCursos
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var instituicaoCursoViewModel = _instituicaoCursoAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "InstituicaoCursos";
            ViewBag.TotalRegistros = _instituicaoCursoAppService.ObterTotalRegistros(pesquisa);

            return View(instituicaoCursoViewModel);
        }

        // GET: InstituicaoCursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var instituicaoCurso = _instituicaoCursoAppService.ObterPorId(id.Value);
            if (instituicaoCurso == null)
            {
                return HttpNotFound();
            }

            return View(instituicaoCurso);
        }

        // GET: InstituicaoCursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstituicaoCursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstituicaoCursoViewModel instituicaoCursoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (!_instituicaoCursoAppService.Adicionar(instituicaoCursoViewModel))
                    {
                        //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                        System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Agente Causador com o mesmo nome!')</SCRIPT>");
                    }
                    else
                        return RedirectToAction("Index");
                }
            }

            return View(instituicaoCursoViewModel);
        }

        // GET: InstituicaoCursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var instituicaoCurso = _instituicaoCursoAppService.ObterPorId(id.Value);
            if (instituicaoCurso == null)
            {
                return HttpNotFound();
            }

            return View(instituicaoCurso);
        }

        // POST: InstituicaoCursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstituicaoCursoViewModel instituicaoCursoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_instituicaoCursoAppService.Atualizar(instituicaoCursoViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Agente Causador com o mesmo nome!')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(instituicaoCursoViewModel);
        }

        // GET: InstituicaoCursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var instituicaoCurso = _instituicaoCursoAppService.ObterPorId(id.Value);
            if (instituicaoCurso == null)
            {
                return HttpNotFound();
            }

            return View(instituicaoCurso);
        }

        // POST: InstituicaoCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_instituicaoCursoAppService.Excluir(id))
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
                _instituicaoCursoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
