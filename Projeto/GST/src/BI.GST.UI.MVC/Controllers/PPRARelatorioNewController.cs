using BI.GST.UI.MVC.DataSet;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BI.GST.UI.MVC.Controllers
{
    public class PPRARelatorioNewController : Controller
    {
        // GET: PPRARelatorioNew
        public ActionResult Index(int ppraId)
        {
            var dataSet = PPRADataSet.AbrirDataSet(ppraId);
            // var PPRATableAdapter = new DataSets.DataSetPPRATableAdapters.PPRATableAdapter();
            ReportViewer reportViewer = new ReportViewer();

            //PPRATableAdapter.Fill(DataSet.PPRA, 12);

            reportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Views\Report\RelatorioPPRA.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("PPRA", (System.Data.DataTable)dataSet.PPRA));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("AgentePPRA", (System.Data.DataTable)dataSet.AgentePPRA));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Cronograma", (System.Data.DataTable)dataSet.CronogramaDeAcoes));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Funcionario", (System.Data.DataTable)dataSet.Funcionario));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Empresa", (System.Data.DataTable)dataSet.Empresa));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Escala", (System.Data.DataTable)dataSet.Escala));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Setor", (System.Data.DataTable)dataSet.Setor));
            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Fisico", (System.Data.DataTable)dataSet.Fisico));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Ergonomico", (System.Data.DataTable)dataSet.Ergonomico));
            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Quimico", (System.Data.DataTable)dataSet.Quimico));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Acidente", (System.Data.DataTable)dataSet.Acidente));
            //reportViewer.Width = System.Web.UI.WebControls.Unit.Percentage(100);
            //  reportViewer.Height = System.Web.UI.WebControls.Unit.Percentage(100);
            // reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Setor", (System.Data.DataTable)dataSet.Setor));

            reportViewer.LocalReport.EnableExternalImages = true;
            reportViewer.LocalReport.Refresh();

            ViewBag.ReportViewer = reportViewer;

            return View();
        }
    }
}