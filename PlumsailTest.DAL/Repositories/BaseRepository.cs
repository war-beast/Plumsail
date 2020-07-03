using System;

namespace PlumsailTest.DAL.Repositories
{
	public abstract class BaseRepository
	{
		protected readonly ApplicationDataContext _db;

		protected BaseRepository(ApplicationDataContext db)
		{
			_db = db ?? throw new ArgumentNullException(nameof(db));
		}
	}
}
