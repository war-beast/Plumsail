using System;
using System.Collections.Generic;
using System.Text;
using PlumsailTest.DAL.Entities;

namespace PlumsailTest.DAL.Interfaces
{
	public interface IUnitOfWorks
	{
		IRepository<Submission> Submission { get; }

		void Save();
	}
}
