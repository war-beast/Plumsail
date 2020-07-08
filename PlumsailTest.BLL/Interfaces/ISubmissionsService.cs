using PlumsailTest.BLL.DTO;
using System.Collections.Generic;

namespace PlumsailTest.BLL.Interfaces
{
	public interface ISubmissionsService
	{
		void SaveSubmission(SubmissionDto submission);

		IEnumerable<SubmissionDto> GetAll();
	}
}
