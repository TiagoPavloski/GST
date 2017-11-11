using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
	public class FileViewModel
	{
		public int FileId { get; set; }

		[StringLength(255)]
		public string FileName { get; set; }

		[StringLength(100)]
		public string ContentType { get; set; }

		public byte[] Content { get; set; }

		public FileTypeViewModel FileType { get; set; }

		public int PersonId { get; set; }


		public virtual EmpresaViewModel Empresa { get; set; }
	}
}
