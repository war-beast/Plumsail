using PlumsailTest.DAL.Entities;
using PlumsailTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PlumsailTest.DAL.Repositories
{
	public class SubmissionsRepository : BaseRepository, IRepository<Submission>
	{
		public SubmissionsRepository(ApplicationDataContext db) : base(db)
		{
			
		}

		public IEnumerable<Submission> GetAll()
		{
			return _db.Submissions.Include(x => x.Parameters);
		}

		public Submission Get(Guid id)
		{
			return _db.Submissions.Include(x => x.Parameters).First(x => x.Id == id);
		}

		public void Create(Submission item)
		{
			#region validation

			if(item == null)
				throw new ArgumentNullException(nameof(item));

			#endregion

			item.Id = Guid.NewGuid();

			item.Parameters = item.Parameters
				.Select(x =>
				{
					x.SubmissionId = item.Id;
					return x;
				})
				.ToList();

			_db.Submissions.Add(item);
		}

		public void Update(Submission item)
		{
			#region validation

			if (item == null)
				throw new ArgumentNullException(nameof(item));

			#endregion
			var local = _db.Submissions
				.First(x => x.Id == item.Id);

			_db.Entry(local).CurrentValues.SetValues(item);
		}

		public void Delete(Guid id)
		{
			var item = _db.Submissions.First(x => x.Id == id);

			_db.Submissions.Remove(item);
		}
	}
}
