using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using PlumsailTest.BLL.Interfaces;
using PlumsailTest.BLL.Interfaces.WebPages;
using PlumsailTest.BLL.Models.ViewModels;
using System;

namespace PlumsailTest.BLL.Services.WebPages
{
	public class HomePageService : IHomePageService
	{
		#region private members

		private readonly ISubmissionsService _submissionsService;

		#endregion

		#region constructor

		public HomePageService(ISubmissionsService submissionsService)
		{
			_submissionsService = submissionsService ?? throw new ArgumentNullException(nameof(submissionsService));
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
