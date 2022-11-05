using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

// First binding will allow us to retrieve an item.
// collectionName == container name
// ConnectionStringSetting is the one we set in local.settings.json
// Id is the record whose JSON we will retrieve from the collection named collectionName
// Counter is where we want to store the data

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"AzureResume", collectionName: "Counter", ConnectionStringSetting = "AzureResumeConnectionString", Id ="1", PartitionKey = "1")] Counter counter,
            [CosmosDB(databaseName:"AzureResume", collectionName: "Counter", ConnectionStringSetting = "AzureResumeConnectionString", Id ="1", PartitionKey = "1")] out Counter updatedCounter,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            updatedCounter = counter;
            updatedCounter.Count += 1;

            var jsonToReturn = JsonConvert.SerializeObject(counter);

            // Initially the JSON data wouldn't load in Firefox. Should have seen "JSON", "Raw Data", "Headers" but instead it tried to download the GetResumeCounter
            // The problem was that the application/json string below had a typo in it, so the browser didn't know it was JSON. Corrected the typo and it worked. 
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK) 
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}
