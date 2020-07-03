using System.Collections.Generic;
using PlumsailTest.BLL.DTO;

namespace PlumsailTest.BLL.Interfaces
{
	public interface ISubmissionsService
	{
		void SaveSubmission(SubmissionDto submission);

		IEnumerable<SubmissionDto> GetAll();
	}
}
