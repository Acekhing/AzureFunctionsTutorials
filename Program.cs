global using AzureFunctionsTutorials.Models;
global using AzureFunctionsTutorials.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AzureFunctionsTutorials;


// Add the FunctionsStartup assembly attribute that specifies
// the type name used during startup.
[assembly: FunctionsStartup(typeof(Program))]

namespace AzureFunctionsTutorials
{
    public class Program : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Dependency injections
            builder.Services.AddTransient<IProductRepository, MockProductRepository>();
        }
    }
}
