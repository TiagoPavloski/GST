using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
    public class SESMTEmpresasController : Controller
    {
        private readonly ISESMTEmpresaAppService _sesmtEmpresaAppService;
        private readonly IEmpresaAppService _empresaAppService;

        public SESMTEmpresasController(ISESMTEmpresaAppService sesmtEmpresaAppService, IEmpresaAppService empresaAppService)
        {
            _sesmtEmpresaAppService = sesmtEmpresaAppService;
            _empresaAppService      = empresaAppService;
        }

        // GET: SESMTEmpresas
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var sesmtEmpresaViewModel = _sesmtEmpresaAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "SESMTEmpresas";
            ViewBag.TotalRegistros = _sesmtEmpresaAppService.ObterTotalRegistros(pesquisa);

            return View(sesmtEmpresaViewModel);
        }

        // GET: SESMTEmpresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sesmtEmpresaViewModel = _sesmtEmpresaAppService.ObterPorId(id.Value);
            if (sesmtEmpresaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(sesmtEmpresaViewModel);
        }

        // GET: SESMTEmpresas/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
            var sesmtEmpresaViewModel = new SESMTEmpresaViewModel();

            return View(sesmtEmpresaViewModel);
        }

        // POST: SESMTEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SESMTEmpresaViewModel sesmtEmpresaViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_sesmtEmpresaAppService.Adicionar(sesmtEmpresaViewModel))
                {
                    ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
                    TempData["Mensagem"] = "Atenção, SESMT já cadastrado para esta empresa";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipoCurso com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }

            return View(sesmtEmpresaViewModel);
        }

        // GET: SESMTEmpresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sesmtEmpresaViewModel = _sesmtEmpresaAppService.ObterPorId(id.Value);
            if (sesmtEmpresaViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia", sesmtEmpresaViewModel.EmpresaId);

            return View(sesmtEmpresaViewModel);
        }

        // POST: SESMTEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SESMTEmpresaViewModel sesmtEmpresaViewModel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia", sesmtEmpresaViewModel.EmpresaId);
                if (!_sesmtEmpresaAppService.Atualizar(sesmtEmpresaViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, SESMT já cadastrado para esta empresa')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(sesmtEmpresaViewModel);
        }

        // GET: SESMTEmpresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sesmtEmpresaViewModel = _sesmtEmpresaAppService.ObterPorId(id.Value);
            if (sesmtEmpresaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(sesmtEmpresaViewModel);
        }

        // POST: SESMTEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_sesmtEmpresaAppService.Excluir(id))
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
                _sesmtEmpresaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
