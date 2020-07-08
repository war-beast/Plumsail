using System.Collections.Generic;
using PlumsailTest.BLL.DTO;
using PlumsailTest.BLL.Models.ViewModels;

namespace PlumsailTest.BLL.Interfaces
{
	public interface ISubmissionsService
	{
		void SaveSubmission(List<FormField> Fields);

		IEnumerable<SubmissionDto> GetAll();
	}
}
