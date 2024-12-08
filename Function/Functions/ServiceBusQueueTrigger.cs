using System;
using Common;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Core.Integration;

namespace Function.Functions
{
    public class ServiceBusQueueTrigger
    {
        private readonly IVPPService _vppService;

        public ServiceBusQueueTrigger(IVPPService vPPService)
        {
            _vppService = vPPService;
        }

        [FunctionName("ServiceBusQueueTrigger")]
        public void Run([ServiceBusTrigger("%ServiceBusPowerReaderQueue%", Connection = "ServiceBusConnectionString")] string myQueueItem, ILogger log)
        {
            var data = (JObject)JsonConvert.DeserializeObject(myQueueItem);
         
            // Here is the decoupled way to handle load balancing
            // The nicer way to do load balancing should be using the _vppService
            
            log.LogInformation($"Need to load balance: {data["Magnitude"]}");
        }
    }
}
