using Microsoft.Extensions.DependencyInjection;
using PlumsailTest.BLL.Interfaces;
using PlumsailTest.BLL.Services;
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

			#region bussiness logic level

			services.AddTransient<ISubmissionsService, SubmissionsService>();

			#endregion
		}
	}
}
