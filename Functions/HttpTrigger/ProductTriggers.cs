using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctionsTutorials.Repository;
using System.Net.Http;

namespace AzureFunctionsTutorials.Functions.HttpTrigger
{
    public class ProductTriggers
    {
        private IProductRepository _productRepository;
        private HttpClient _httpClient;

        public ProductTriggers(IProductRepository productRepository, HttpClient httpClient)
        {
            _productRepository = productRepository;
            _httpClient = httpClient;
        }

        [FunctionName("GetAllProducts")]
        public async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetAllProducts triggered");
            var products = _productRepository.GetAll();
            return new OkObjectResult(products);
        }


        [FunctionName("GetProductById")]
        public async Task<IActionResult> GetById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products/{ID}")] HttpRequest req,
            ILogger log, long ID)
        {
            log.LogInformation("GetProductById triggered");
            var product = _productRepository.GetById(ID);
            if (product == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(product);
        }


        [FunctionName("SearchProduct")]
        public async Task<IActionResult> Find(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products/search/{name}")] HttpRequest req,
            ILogger log, string name)
        {
            log.LogInformation("SearchProduct triggered");
            var products = _productRepository.Find(name);
            if (products == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(products);
        }

        [FunctionName("UpdateProduct")]
        public async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "products")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("SearchProduct triggered");
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            Product product;
            try
            {
                product = JsonConvert.DeserializeObject<Product>(requestBody);
            }
            catch
            {
                return new BadRequestObjectResult("Invalid Json");
            }

            try
            {
                var result = _productRepository.Update(product);
                if (result == -1)
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(new { Id = result });
            }
            catch (Exception ex)
            {
                return new UnprocessableEntityObjectResult(ex.Message);
            }

        }

    }
}
