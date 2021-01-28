using Atlas.Infrastructure.Abstraction.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Atlas.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDataAccess(this IServiceCollection serviceCollection)
        {
            //SQLitePCL.raw.SetProvider();
            serviceCollection.AddSingleton<IAppDbContext, AppDbContext>();
        }
    }
}
