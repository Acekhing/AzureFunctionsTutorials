using Microsoft.Extensions.DependencyInjection;

namespace AzureFunctionsTutorials
{
    public static class ServiceInjector
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, MockProductRepository>();
        }
    }
}
