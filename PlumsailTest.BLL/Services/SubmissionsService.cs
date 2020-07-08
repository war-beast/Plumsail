using AutoMapper;
using Newtonsoft.Json;
using PlumsailTest.BLL.DTO;
using PlumsailTest.BLL.Interfaces;
using PlumsailTest.DAL.Entities;
using PlumsailTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using PlumsailTest.BLL.Models.ViewModels;

namespace PlumsailTest.BLL.Services
{
	public class SubmissionsService : BaseService, ISubmissionsService
	{
		#region private members

		private readonly IMapper _mapper;

		#endregion

		#region constructor

		public SubmissionsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
		{
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		#endregion

		public void SaveSubmission(List<FormField> fields)
		{
			foreach (var field in fields)
			{
				
			}
			//var coreSubmission = _mapper.Map<Submission>(submission);
			//_unitOfWork.Submission.Create(coreSubmission);

			//_unitOfWork.Save();
		}

		public IEnumerable<SubmissionDto> GetAll()
		{
			var existingSubmissions = _unitOfWork.Submission.GetAll();
			return _mapper.Map<IEnumerable<SubmissionDto>>(existingSubmissions);
		}
	}
}
