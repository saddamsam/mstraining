
using Azure;
using ClaimAPI.Models;
using ClaimAPI.Repository;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace ClaimAPI.Services
{
    public class PolicyConsumerService : BackgroundService
    {
        private IConfiguration _configuration;
        private IPolicyRepo _policyRepo;
        private string response;

        public PolicyConsumerService(IConfiguration configuration, IPolicyRepo policyRepo)
        {
            _configuration = configuration;
            _policyRepo = policyRepo;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string bootstrapServer = _configuration["BootstrapServer"];
            string groupId = _configuration["GroupId"];
            string topicName = _configuration["TopicName"];

            return ConsumePolicyData(topicName, groupId,bootstrapServer);


        }


        private async Task<string> ConsumePolicyData(string TopicName,string GroupId,string BootstrapServer)
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = BootstrapServer,
                GroupId = GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var c = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
            {
                c.Subscribe(TopicName);

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cts.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume(cts.Token);
                            Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                            response = $"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.";
                            var result = JsonConvert.DeserializeObject<List<Policy>>(cr.Value);
                            foreach (var policy in result)
                                _policyRepo.AddPolicy(policy);
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
                            response = $"Error occured: {e.Error.Reason}";
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
                return response;

            }


        }
            

    }
}
