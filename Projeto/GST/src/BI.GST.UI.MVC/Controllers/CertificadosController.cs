using System.Linq;
using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using System.Collections.Generic;
using BI.GST.Application.ViewModels;
using Rotativa;
using Rotativa.Options;

namespace BI.GST.UI.MVC.Controllers
{
    public class CertificadosController : Controller
    {
        private readonly ICertificadoAppService _certificadoAppService;
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly ICursoAppService _cursoAppService;
        private readonly IInstituicaoCursoAppService _instituicaoCursoAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly ITipoCursoAppService _tipoCursoAppService;

        public CertificadosController(ICertificadoAppService certificadoAppService, IFuncionarioAppService funcionarioAppService, ICursoAppService cursoAppService,
            IInstituicaoCursoAppService instituicaoCursoAppService, IEmpresaAppService empresaAppService, ITipoCursoAppService tipoCursoAppService)
        {
            _certificadoAppService = certificadoAppService;
            _funcionarioAppService = funcionarioAppService;
            _cursoAppService = cursoAppService;
            _instituicaoCursoAppService = instituicaoCursoAppService;
            _empresaAppService = empresaAppService;
            _tipoCursoAppService = tipoCursoAppService;
        }

        public JsonResult Funcionario(int idEmpresa, int idCurso, string dataRealizacao)
        {
            return Json(_funcionarioAppService.ObterFuncionariosEC(idEmpresa, idCurso, dataRealizacao), JsonRequestBehavior.AllowGet);
        }


        // GET: Certificados
        public ActionResult Index(string pesquisa, int page =0)
        {
            var certificadosViewModel = _certificadoAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "Certificados";
            ViewBag.TotalRegistros = _certificadoAppService.ObterTotalRegistros(pesquisa);

            #region DDL Status
            List<SelectListItem> ddlStatusCertificado = new List<SelectListItem>();
            ddlStatusCertificado.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatusCertificado.Add(new SelectListItem() { Text = "Vencido", Value = "2" });
            TempData["ddlStatusCertificado"] = ddlStatusCertificado;

            foreach (var item in certificadosViewModel)
            {
                item.StatusNome = ddlStatusCertificado.Where(e => e.Value.Trim().Equals(item.Status.ToString())).First().Text;
            }
            #endregion

            return View(certificadosViewModel);
        }

        // GET: Certificados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var certificado = _certificadoAppService.ObterPorId(id.Value);
            if (certificado == null)
            {
                return HttpNotFound();
            }

            var ddlStatusCertificado = (List<SelectListItem>)TempData["ddlStatusCertificado"];
            certificado.StatusNome = ddlStatusCertificado.Where(e => e.Value.Trim().Equals(certificado.Status.ToString())).First().Text;

            return View(certificado);
        }

        // GET: Certificados/Create
        public ActionResult Create()
        {
            var certificadoViewModel = new CertificadoViewModel();

            List<SelectListItem> ddlStatusCertificado = new List<SelectListItem>();
            ddlStatusCertificado.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatusCertificado.Add(new SelectListItem() { Text = "Vencido", Value = "2" });
            TempData["ddlStatusCertificado"] = ddlStatusCertificado;

            ViewBag.TipoCursoId = new SelectList(_tipoCursoAppService.ObterTodos(), "TipoCursoId", "Nome");
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
            ViewBag.CursoId = new SelectList(_cursoAppService.ObterTodos(), "CursoId", "Data");
            ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterPorEmpresa(certificadoViewModel.EmpresaId), "FuncionarioId", "Nome");
            ViewBag.InstituicaoCursoId = new SelectList(_instituicaoCursoAppService.ObterTodos(), "InstituicaoCursoId", "Nome");

            return View(certificadoViewModel);
        }

        // POST: Certificados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CertificadoViewModel certificadoViewModel, int[] funcionarios)
        {
             if (ModelState.IsValid)
            {
                if (!_certificadoAppService.Adicionar(certificadoViewModel, funcionarios))
                {
                        TempData["Mensagem"] = "Atenção, há um certificado com os mesmos dados já cadastrado";
                    }
                else
                    return RedirectToAction("Index");
            }

            List<SelectListItem> ddlStatusCertificado = new List<SelectListItem>();
            ddlStatusCertificado.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatusCertificado.Add(new SelectListItem() { Text = "Vencido", Value = "2" });
            TempData["ddlStatusCertificado"] = ddlStatusCertificado;

            ViewBag.TipoCursoId = new SelectList(_tipoCursoAppService.ObterTodos(), "TipoCursoId", "Nome");
            ViewBag.CursoId = new SelectList(_cursoAppService.ObterTodos(), "CursoId", "Data");
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId, NomeFantasia");
            ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome");
            ViewBag.InstituicaoCursoId = new SelectList(_instituicaoCursoAppService.ObterTodos(), "InstituicaoCursoId", "Nome");

            return View(certificadoViewModel);
        }

        // GET: Certificados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var certificado = _certificadoAppService.ObterPorId(id.Value);
            if (certificado == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> ddlStatusCertificado = new List<SelectListItem>();
            ddlStatusCertificado.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatusCertificado.Add(new SelectListItem() { Text = "Vencido", Value = "2" });
            TempData["ddlStatusCertificado"] = ddlStatusCertificado;

            ViewBag.CursoId = new SelectList(_cursoAppService.ObterTodos(), "CursoId", "Data", certificado.CursoId);
            ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome", certificado.FuncionarioId);
            ViewBag.InstituicaoCursoId = new SelectList(_instituicaoCursoAppService.ObterTodos(), "InstituicaoCursoId", "Nome", certificado.InstituicaoCursoId);

            return View(certificado);
        }

        // POST: Certificados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CertificadoViewModel certificadoViewModel)
        {

            if (ModelState.IsValid)
            {
                if (!_certificadoAppService.Atualizar(certificadoViewModel))
                {
                    TempData["Mensagem"] = "Atenção, há um certificado com os mesmos dados já cadastrado";
                }
                else
                    return RedirectToAction("Index");
            }
            return View(certificadoViewModel);
        }

        // GET: Certificados/Delete/5
        public ActionResult Delete(int? id)
        {
            List<SelectListItem> ddlStatusCertificado = new List<SelectListItem>();
            ddlStatusCertificado.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatusCertificado.Add(new SelectListItem() { Text = "Vencido", Value = "2" });
            TempData["ddlStatusCertificado"] = ddlStatusCertificado;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var certificado = _certificadoAppService.ObterPorId(id.Value);
            if (certificado == null)
            {
                return HttpNotFound();
            }

            var ddlStatusCertificados = (List<SelectListItem>)TempData["ddlStatusCertificado"];
            certificado.StatusNome = ddlStatusCertificados.Where(e => e.Value.Trim().Equals(certificado.Status.ToString())).First().Text;
            return View(certificado);
        }

        // POST: Certificados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_certificadoAppService.Excluir(id))
            {
                TempData["Mensagem"] = "Erro, atualize a página";
                return RedirectToAction("Index");
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
                _certificadoAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Gerar(int? id)
        {
            var certificado = _certificadoAppService.ObterPorId(id.Value);


            var pdf = new ViewAsPdf() {

                ViewName = "Gerar",
                Model = certificado,
                FileName = "Certificado.pdf",
                PageSize = Size.A4,
                PageOrientation = Orientation.Landscape,
                PageMargins = new Margins { Bottom = 0, Left = 0, Right = 0, Top = 0 },
            };
                
            
            return pdf;
        }
    }
}
