using PlumsailTest.BLL.DTO;
using PlumsailTest.BLL.Models.ViewModels;

namespace PlumsailTest.BLL.Interfaces
{
	public interface ISubmissionsService
	{
		void SaveSubmission(SubmissionViewModel submission);
	}
}
