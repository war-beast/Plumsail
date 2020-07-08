using System.Collections.Generic;
using PlumsailTest.BLL.Models.ViewModels;

namespace PlumsailTest.BLL.DTO
{
	public class SubmissionDto : BaseDto
	{
		public List<FormField> Fields { get; set; }
	}
}
