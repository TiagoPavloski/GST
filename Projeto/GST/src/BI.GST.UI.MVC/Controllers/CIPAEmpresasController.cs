using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BI.GST.UI.MVC.Controllers
{
    public class CIPAEmpresasController : Controller
    {
        private readonly ICIPAEmpresaAppService _cipaEmpresaAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly ICipaQuadroAppService _cipaQuadroAppService;
        private CipaQuadroViewModel QuadroCipa;

        public CIPAEmpresasController(ICIPAEmpresaAppService cipaEmpresaAppService, IEmpresaAppService empresaAppService,
              IFuncionarioAppService funcionarioAppService, ICipaQuadroAppService cipaQuadroAppService)
        {
            _cipaEmpresaAppService = cipaEmpresaAppService;
            _empresaAppService = empresaAppService;
            _funcionarioAppService = funcionarioAppService;
            _cipaQuadroAppService = cipaQuadroAppService;
        }

        public JsonResult Funcionario(int id)

        {
            return Json(_funcionarioAppService.ObterPorEmpresa(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DadosCipa(int id)
        {
            CIPAEmpresaViewModel cipaEmpresa = new CIPAEmpresaViewModel();
            var empresa = _empresaAppService.ObterPorId(id);
            var numeroFuncionarios = _funcionarioAppService.ObterTotalPorEmpresa(id);
            QuadroCipa = _cipaQuadroAppService.obterCipaPorGrupo(numeroFuncionarios, empresa.CnaePrincipal.GrupoCipa.GrupoCipaId);

            cipaEmpresa.NumeroFuncionarios = numeroFuncionarios;
            if (QuadroCipa != null)
            {
                cipaEmpresa.NumeroFuncionariosEfetivos = QuadroCipa.QuantidadeEfetivos;
                cipaEmpresa.NumeroFuncionariosSuplentes = QuadroCipa.QuantidadeSuplentes;

            }
            return Json(cipaEmpresa, JsonRequestBehavior.AllowGet);
        }

        // GET: CIPAEmpresas
        public ActionResult Index(string pesquisa, int page = 0)
        {
            QuadroCipa = new CipaQuadroViewModel();
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
            ViewBag.FuncionariosEfetivos = new SelectList(_funcionarioAppService.ObterPorEmpresa(cipaEmpresaViewModel.EmpresaId), "FuncionarioId", "Nome");
            ViewBag.FuncionariosSuplentes = new SelectList(_funcionarioAppService.ObterPorEmpresa(cipaEmpresaViewModel.EmpresaId), "FuncionarioId", "Nome");
            return View(cipaEmpresaViewModel);
        }

        // POST: CIPAEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CIPAEmpresaViewModel cipaEmpresaViewModel, int[] FuncionariosEfetivos, int[] FuncionariosSuplentes)
        {
            if (ModelState.IsValid)
            {
                var result = _cipaEmpresaAppService.Adicionar(ref cipaEmpresaViewModel, FuncionariosEfetivos, FuncionariosSuplentes);
                if (result != "")
                {
                    ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
                    //var cipaEmpresa = new CIPAEmpresaViewModel();
                    TempData["Mensagem"] = result;
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipoCurso com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");

                var listaFuncionarios = _funcionarioAppService.ObterPorEmpresa(cipaEmpresaViewModel.EmpresaId);
                ViewBag.FuncionariosEfetivos = new SelectList(listaFuncionarios, "FuncionarioId", "Nome", FuncionariosEfetivos);
                ViewBag.FuncionariosSuplentes = new SelectList(listaFuncionarios, "FuncionarioId", "Nome", FuncionariosSuplentes);
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
            ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome");

            var listaFuncionarios = _funcionarioAppService.ObterPorEmpresa(cipaEmpresaViewModel.EmpresaId);

            ViewBag.FuncionariosEfetivos  = new SelectList(listaFuncionarios, "FuncionarioId", "Nome", cipaEmpresaViewModel.CIPAEmpresaFuncionarios.Select(x => x.FuncionarioId));
            ViewBag.FuncionariosSuplentes = new SelectList(listaFuncionarios, "FuncionarioId", "Nome", cipaEmpresaViewModel.CIPAEmpresaFuncionarios.Select(x => x.FuncionarioId));

            return View(cipaEmpresaViewModel);
        }

        // POST: CIPAEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CIPAEmpresaViewModel cipaEmpresaViewModel, int[] FuncionariosEfetivos, int[] FuncionariosSuplentes)
        {
            if (ModelState.IsValid)
            {
                ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia", cipaEmpresaViewModel.EmpresaId);
                var result = _cipaEmpresaAppService.Adicionar(ref cipaEmpresaViewModel, FuncionariosEfetivos, FuncionariosSuplentes);
                if (result != "")
                    TempData["Mensagem"] = result;
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
