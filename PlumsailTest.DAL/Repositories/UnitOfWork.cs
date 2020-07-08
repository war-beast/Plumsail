using Microsoft.EntityFrameworkCore;
using PlumsailTest.DAL.Entities;
using PlumsailTest.DAL.Interfaces;
using System;

namespace PlumsailTest.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		#region private members

		private ApplicationDataContext _db;
		private SubmissionsRepository _submissionsRepository;
		private ParametersRepository _parametersRepository;

		private bool disposed = false;

		#endregion

		#region constructor

		public UnitOfWork(DbContextOptions<ApplicationDataContext> options)
		{
			if (options == null)
				throw new ArgumentNullException(nameof(options));

			_db = new ApplicationDataContext(options);
		}

		#endregion

		public IRepository<Submission> Submission => _submissionsRepository ??= new SubmissionsRepository(_db);

		public IRepository<FieldParameter> Parameters => _parametersRepository ??= new ParametersRepository(_db);

		public void Save()
		{
			_db.SaveChanges();
		}

		public virtual void Dispose(bool disposing)
		{
			if (disposed) 
				return;

			if (disposing)
			{
				_db.Dispose();
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
