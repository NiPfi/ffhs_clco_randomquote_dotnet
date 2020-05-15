using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace ClCo.RandomQuote
{
    public static class random_quote
    {
        private static readonly string apiUrl = "https://clco.blob.core.windows.net/qoutes/quotes.txt";
        private static readonly HttpClient client = new HttpClient();
        private static readonly Random random = new Random();

        [FunctionName("random_quote")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var quoteString = await client.GetStringAsync(apiUrl);
            var quotes = quoteString.Split("\n");
            var randomIndex = random.Next(quotes.Length);
            return new OkObjectResult(new Quote(quotes[randomIndex]));
        }
    }
}
