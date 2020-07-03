using Microsoft.Extensions.DependencyInjection;
using PlumsailTest.DAL.Interfaces;
using PlumsailTest.DAL.Repositories;

namespace PlumsailTest
{
	public partial class Startup
	{
		private void ConfigureCustomServices(IServiceCollection services)
		{
			#region MyRegion

			services.AddTransient<IUnitOfWork, UnitOfWork>();

			#endregion
		}
	}
}
