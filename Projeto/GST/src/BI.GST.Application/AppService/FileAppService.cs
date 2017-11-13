using AutoMapper;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.AppService
{
	public class FileAppService : BaseAppService, IFileAppService
	{
		private readonly IFileService _fileService;

		public FileAppService(IFileService fileService)
		{
			_fileService = fileService;
		}

		public void Dispose()
		{
			_fileService.Dispose();
			GC.SuppressFinalize(this);
		}

		public FileViewModel ObterPorId(int id)
		{
			return Mapper.Map<File, FileViewModel>(_fileService.ObterPorId(id));
		}

		public IEnumerable<FileViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<File>, IEnumerable<FileViewModel>>(_fileService.ObterTodos());
		}

	}
}
