using PlumsailTest.BLL.DTO;
using PlumsailTest.BLL.Interfaces;
using System;
using AutoMapper;
using PlumsailTest.DAL.Interfaces;

namespace PlumsailTest.BLL.Services
{
	public class SearchService : BaseService, ISearchService
	{
		#region private members

		private readonly IMapper _mapper;

		#endregion

		#region constructor

		public SearchService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
		{
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		#endregion

		public SubmissionDto Find(string phrase)
		{
			throw new NotImplementedException();
		}
	}
}
