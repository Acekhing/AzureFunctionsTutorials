using System;
using System.Linq;
using AzureFunctionsTutorials.Repository;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsTutorials.Functions.TimerTrigger
{
    public class ExampleTimerTrigger
    {
        private IProductRepository _productRepository;

        public ExampleTimerTrigger(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // */5 * * * * Runs every 5 seconds
        [FunctionName("Greet")]
        public void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"GetAllProductsEvevrySecond executed at: {DateTime.Now}");
            log.LogInformation("Hello world, I will come back in the next five seconds");
        }

    }
}
