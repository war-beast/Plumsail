using PlumsailTest.BLL.DTO;

namespace PlumsailTest.BLL.Interfaces
{
	public interface ISearchService
	{
		SubmissionDto Find(string phrase);
	}
}
