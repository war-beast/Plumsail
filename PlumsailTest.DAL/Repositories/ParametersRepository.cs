using PlumsailTest.DAL.Entities;
using PlumsailTest.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PlumsailTest.DAL.Repositories
{
	public class ParametersRepository : BaseRepository, IRepository<FieldParameter>
	{
		#region constructor

		public ParametersRepository(ApplicationDataContext db) : base(db)
		{
			
		}

		#endregion

		public IEnumerable<FieldParameter> GetAll()
		{
			return _db.FieldParameters;
		}

		public FieldParameter Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public void Create(FieldParameter item)
		{
			throw new NotImplementedException();
		}

		public void Update(FieldParameter item)
		{
			throw new NotImplementedException();
		}

		public void Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
