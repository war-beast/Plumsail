using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlumsailTest.BLL.Models.ViewModels
{
	public class FormField
	{
		[Required]
		public string Name { get; set; }


		[Required]
		public string Value { get; set; }
	}
}
