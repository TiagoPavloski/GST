using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
	public interface IFileService : IDisposable
	{
		IEnumerable<File> ObterTodos();

		File ObterPorId(int id);

		IEnumerable<File> Find(Expression<Func<File, bool>> predicate);
	}
}
