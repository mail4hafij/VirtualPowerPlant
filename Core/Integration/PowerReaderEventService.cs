using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Core.Integration
{
    public class PowerReaderEventService : IPowerReaderEventService
    {
        IConfiguration _configuration;

        public PowerReaderEventService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EmitPowerReaderEvent(PowerReader powerReader)
        {
            var connectionString = _configuration["ServiceBusConnectionString"];
            var powerReaderQueue = _configuration["ServiceBusPowerReaderQueue"];

            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(powerReaderQueue);

            string body = JsonConvert.SerializeObject(powerReader);
            var message = new ServiceBusMessage(body);

            await sender.SendMessageAsync(message);
        }
    }

    public class PowerReader
    {
        public int BatteryPoolId { get; set; }
        public int Magnitude { get; set; }
    }
}
