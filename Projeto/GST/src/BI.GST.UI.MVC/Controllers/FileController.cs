using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BI.GST.UI.MVC.Controllers
{
	public class FileController : Controller
	{
		private readonly IFileAppService _fileAppService;

		public FileController(IFileAppService fileAppService)
		{
			_fileAppService = fileAppService;
		}

		// GET: File
		public ActionResult Index(int id)
		{
			var fileToRetrieve = _fileAppService.ObterPorId(id);
			return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
		}
	}
}