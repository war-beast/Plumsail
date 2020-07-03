using Microsoft.Extensions.DependencyInjection;
using PlumsailTest.BLL.Interfaces;
using PlumsailTest.BLL.Interfaces.WebPages;
using PlumsailTest.BLL.Services;
using PlumsailTest.BLL.Services.WebPages;
using PlumsailTest.DAL.Interfaces;
using PlumsailTest.DAL.Repositories;

namespace PlumsailTest
{
	public partial class Startup
	{
		private void ConfigureCustomServices(IServiceCollection services)
		{
			#region data level

			services.AddTransient<IUnitOfWork, UnitOfWork>();

			#endregion

			#region businesslogic level

			services.AddTransient<ISubmissionsService, SubmissionsService>();

			#endregion

			#region MyRegion

			services.AddTransient<IHomePageService, HomePageService>();

			#endregion
		}
	}
}
