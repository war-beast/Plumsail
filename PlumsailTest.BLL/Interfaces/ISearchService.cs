using System.Collections.Generic;
using PlumsailTest.BLL.DTO;

namespace PlumsailTest.BLL.Interfaces
{
	public interface ISearchService
	{
		IEnumerable<SubmissionDto> Find(string phrase);
	}
}
