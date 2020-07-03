using System;
using PlumsailTest.DAL.Interfaces;

namespace PlumsailTest.BLL.Services
{
	public class BaseService
	{
		#region private members

		protected readonly IUnitOfWork _unitOfWork;

		#endregion

		#region constructor

		public BaseService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		#endregion
	}
}
