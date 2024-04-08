
using Confluent.Kafka;
using System.Diagnostics;
using System.Net;

namespace Policy_API.Repository
{
    public class PolicyPublishRepo : IPolicyPublishRepo
    {
        public async Task<string> PublishPolicyData(string TopicName, string Message, IConfiguration configuration)
        {
            ProducerConfig producerConfig = new ProducerConfig
            {
                BootstrapServers = configuration["BootstrapServer"],
                ClientId = Dns.GetHostName()
            };
            try
            {
                using (var ProducerBuilder = new ProducerBuilder<string, string>(producerConfig).Build())
                {
                    var result = await ProducerBuilder.ProduceAsync(TopicName, new Message<string, string>
                    {
                        Key = new Random().Next(5).ToString(),
                        Value = Message
                    });
                    Debug.WriteLine($"Delivery Timestamp:{result.Timestamp.UtcDateTime}");
                    ProducerBuilder.Flush(TimeSpan.FromSeconds(60));
                    return await Task.FromResult($"Delivery Timestamp:{result.Timestamp.UtcDateTime}");

                }




            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured {ex.Message.ToString()}");
            }

            return await Task.FromResult("Not Published.....");
        }
    }
}
