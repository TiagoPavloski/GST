using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Services
{
	public class FileService : IFileService
	{
		private readonly IFileRepository _fileRepository;

		public FileService(IFileRepository fileRepository)
		{
			_fileRepository = fileRepository;
		}

		public IEnumerable<File> Find(Expression<Func<File, bool>> predicate)
		{
			return _fileRepository.Find(predicate);
		}

		public File ObterPorId(int id)
		{
			return _fileRepository.ObterPorId(id);
		}

		public IEnumerable<File> ObterTodos()
		{
			return _fileRepository.ObterTodos();
		}

		public void Dispose()
		{
			_fileRepository.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
