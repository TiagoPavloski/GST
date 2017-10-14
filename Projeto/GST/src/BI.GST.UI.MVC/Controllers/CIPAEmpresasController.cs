using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
    public class CIPAEmpresasController : Controller
    {
        private readonly ICIPAEmpresaAppService _cipaEmpresaAppService;
        private readonly IEmpresaAppService _empresaAppService;
        //private readonly IFuncionarioEmpresaAppService _FuncionarioempresaAppService;

        public CIPAEmpresasController(ICIPAEmpresaAppService cipaEmpresaAppService, IEmpresaAppService empresaAppService)
        {
            _cipaEmpresaAppService = cipaEmpresaAppService;
            _empresaAppService     = empresaAppService;
        }

        // GET: CIPAEmpresas
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var cipaEmpresaViewModel = _cipaEmpresaAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "CIPAEmpresas";
            ViewBag.TotalRegistros = _cipaEmpresaAppService.ObterTotalRegistros(pesquisa);

            return View(cipaEmpresaViewModel);
        }

        // GET: CIPAEmpresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cipaEmpresaViewModel = _cipaEmpresaAppService.ObterPorId(id.Value);
            if (cipaEmpresaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cipaEmpresaViewModel);
        }

        // GET: CIPAEmpresas/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
            var cipaEmpresaViewModel = new CIPAEmpresaViewModel();

            return View(cipaEmpresaViewModel);
        }

        // POST: CIPAEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CIPAEmpresaViewModel cipaEmpresaViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_cipaEmpresaAppService.Adicionar(cipaEmpresaViewModel))
                {
                    ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
                    //var cipaEmpresa = new CIPAEmpresaViewModel();
                    TempData["Mensagem"] = "Atenção, CIPA já cadastrada para esta empresa e ano";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipoCurso com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }

            return View(cipaEmpresaViewModel);
        }

        // GET: CIPAEmpresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cipaEmpresaViewModel = _cipaEmpresaAppService.ObterPorId(id.Value);
            if (cipaEmpresaViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia", cipaEmpresaViewModel.EmpresaId);

            return View(cipaEmpresaViewModel);
        }

        // POST: CIPAEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CIPAEmpresaViewModel cipaEmpresaViewModel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia", cipaEmpresaViewModel.EmpresaId);
                if (!_cipaEmpresaAppService.Atualizar(cipaEmpresaViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, CIPA já cadastrada para esta empresa e ano')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(cipaEmpresaViewModel);
        }

        // GET: CIPAEmpresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cipaEmpresaViewModel = _cipaEmpresaAppService.ObterPorId(id.Value);
            if (cipaEmpresaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cipaEmpresaViewModel);
        }

        // POST: CIPAEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_cipaEmpresaAppService.Excluir(id))
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
                _cipaEmpresaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
