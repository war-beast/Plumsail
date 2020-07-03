using System.ComponentModel.DataAnnotations;

namespace PlumsailTest.BLL.Models.ViewModels
{
	public class SubmissionViewModel
	{
		[Required]
		public string SerializedJsonValue { get; set; }
	}
}
