using Microsoft.AspNetCore.Mvc;
using PlumsailTest.BLL.Interfaces.WebPages;
using PlumsailTest.Models;
using System;
using System.Diagnostics;

namespace PlumsailTest.Controllers
{
	public class HomeController : Controller
	{
		#region private members

		private readonly IHomePageService _homePageService;

		#endregion

		#region constructor
		public HomeController(IHomePageService homePageService)
		{
			_homePageService = homePageService ?? throw new ArgumentNullException(nameof(homePageService));
		}

		#endregion

		public IActionResult Index()
		{
			var model = _homePageService.GetPage();
			return View(model);
		}

		public IActionResult AddingForm()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
