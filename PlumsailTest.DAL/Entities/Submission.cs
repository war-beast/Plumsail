using System.Collections.Generic;

namespace PlumsailTest.DAL.Entities
{
	public class Submission : BaseEntity
	{
		public ICollection<FieldParameter> Parameters { get; set; }
	}
}
