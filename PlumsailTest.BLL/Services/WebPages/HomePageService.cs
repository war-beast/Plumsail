using PlumsailTest.BLL.Interfaces.WebPages;
using PlumsailTest.BLL.Models.ViewModels;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using PlumsailTest.BLL.Interfaces;

namespace PlumsailTest.BLL.Services.WebPages
{
	public class HomePageService : IHomePageService
	{
		#region private members

		private readonly ISubmissionsService _submissionsService;
		private readonly IMapper _mapper;

		#endregion

		#region constructor

		public HomePageService(ISubmissionsService submissionsService, IMapper mapper)
		{
			_submissionsService = submissionsService ?? throw new ArgumentNullException(nameof(submissionsService));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		#endregion

		public HomeViewModel GetPage()
		{
			return new HomeViewModel
			{
				AnySubmissionExist = _submissionsService.GetAll().Any()
			};
		}
	}
}
