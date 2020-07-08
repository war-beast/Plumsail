using System.Collections.Generic;
using System.Threading.Tasks;
using PlumsailTest.BLL.DTO;

namespace PlumsailTest.BLL.Interfaces
{
	public interface ISearchService
	{
		Task<IEnumerable<SubmissionDto>> Find(string phrase);
	}
}
