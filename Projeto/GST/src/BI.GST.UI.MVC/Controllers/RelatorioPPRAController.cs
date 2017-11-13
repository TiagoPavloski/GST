using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BI.GST.UI.MVC.Controllers
{
    public class RelatorioPPRAController : Controller
    {
        // GET: RelatorioPPRA
        public ActionResult Index()
        {
            var DataSet = DataSets.DataSetPPRA.AbrirDataSet(12);
           // var PPRATableAdapter = new DataSets.DataSetPPRATableAdapters.PPRATableAdapter();
            ReportViewer reportViewer = new ReportViewer();

            //PPRATableAdapter.Fill(DataSet.PPRA, 12);

            reportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Views\Reports\RelatorioPPRA.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("PPRA", (System.Data.DataTable)DataSet.PPRA));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("AgentePPRA", (System.Data.DataTable)DataSet.AgentePPRA));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Cronograma", (System.Data.DataTable)DataSet.CronogramaDeAcoes));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Funcionario", (System.Data.DataTable)DataSet.Funcionario));
            //reportViewer.Width = System.Web.UI.WebControls.Unit.Percentage(100);
          //  reportViewer.Height = System.Web.UI.WebControls.Unit.Percentage(100);

            reportViewer.LocalReport.EnableExternalImages = true;
            reportViewer.LocalReport.Refresh();
    
            ViewBag.ReportViewer = reportViewer;

            return View();

        }
    }
}