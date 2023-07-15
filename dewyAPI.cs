using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Dewy
{
    public class dewyAPI
    {
        [FunctionName("getHumidity")]
        public async Task<IActionResult> GetHumidity(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("HTTP trigger function processed humidity request.");

            string lat = req.Query["lat"];
            string lon = req.Query["long"];

            // to  do : create Open weather map class and return humidity 
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            return new OkObjectResult(requestBody);
        }

        [FunctionName("getUVIndex")]
        public async Task<IActionResult> GetUVIndex(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("HTTP trigger function processed UV index request.");

            string lat = req.Query["lat"];
            string lon = req.Query["long"];

            // to  do : create Open weather map class and return UV index
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            return new OkObjectResult(requestBody);
        }
    }
}
