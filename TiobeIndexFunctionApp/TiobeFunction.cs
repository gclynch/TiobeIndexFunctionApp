// function app for TIOBE index

// http://<APP_NAME>.azurewebsites.net/api/<FUNCTION_NAME>
// curl -v https://tiobeindexgc.azurewebsites.net/api/tiobeindex
// curl -v http://localhost:7071/api/TiobeIndex

// configure CORS in portal for function app to allow CORS request from Blazor app
// e.g. http://localhost:55850, https://tiobeindexgc.azurewebsites.net
// or *
//

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace TiobeIndexFunctionApp
{
    public class TiobeFunction
    {
        private readonly ILogger<TiobeFunction> _logger;

        public TiobeFunction(ILogger<TiobeFunction> logger)
        {
            _logger = logger;
        }

        [Function("TiobeIndex")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            TiobeIndexEntry[] data = new TiobeIndexEntry[]
             {
                new TiobeIndexEntry() {Language = "Python", Rating = 21.9},
                new TiobeIndexEntry() {Language = "C++", Rating = 11.6},
                new TiobeIndexEntry() {Language = "Java", Rating = 10.51},
                new TiobeIndexEntry() {Language = "C#", Rating = 5.62}
             };

            return new OkObjectResult(data);
        }
    }

    public class TiobeIndexEntry
    {
        public string? Language { get; set; }
        public double Rating { get; set; }
    }
}
