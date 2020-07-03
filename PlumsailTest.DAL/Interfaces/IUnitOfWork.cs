using System;
using System.Collections.Generic;
using System.Text;
using PlumsailTest.DAL.Entities;

namespace PlumsailTest.DAL.Interfaces
{
	public interface IUnitOfWork
	{
		IRepository<Submission> Submission { get; }

		void Save();
	}
}
