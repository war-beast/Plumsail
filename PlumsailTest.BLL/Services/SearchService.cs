using PlumsailTest.BLL.DTO;
using PlumsailTest.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public IEnumerable<SubmissionDto> Find(string phrase)
		{
			var parameters = _unitOfWork
				.Parameters
				.GetAll()
				.Where(x => x.Value.Contains(phrase, StringComparison.InvariantCultureIgnoreCase))
				.Select(x => x.SubmissionId)
				.Distinct();

			var submissionsWithDependent = parameters
				.Select(x => _unitOfWork.Submission.Get(x))
				.ToList();

			return _mapper.Map<IEnumerable<SubmissionDto>>(submissionsWithDependent);
		}
	}
}
