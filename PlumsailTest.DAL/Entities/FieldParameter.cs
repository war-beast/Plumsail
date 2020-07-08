using System;

namespace PlumsailTest.DAL.Entities
{
	public class FieldParameter : BaseEntity
	{
		public string Name { get; set; }

		public string Value { get; set; }

		public Guid SubmissionId { get; set; }

		#region navigation

		public Submission Submission { get; set; }

		#endregion
	}
}
