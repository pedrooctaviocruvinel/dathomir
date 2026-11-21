using Confluent.Kafka;
using Dathomir.Backoffice.Application.Providers.Events;
using Microsoft.Extensions.Options;

namespace Dathomir.Backoffice.Infrastructure.Provider.Kafka;

public class EventProducer<T> : IEventProducer<T> where T : class
{
    private readonly IProducer<string, T> _producer;
    private readonly string _topic;

    public EventProducer(IOptions<KafkaConfiguration> kafkaConfiguration, string topic)
    {
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = kafkaConfiguration.Value.BootstrapServers,
            Acks = Acks.All
        };

        _producer = new ProducerBuilder<string, T>(producerConfig)
          .SetValueSerializer(new KafkaJsonSerializer<T>())
          .Build();
        _topic = topic;
    }

    public async Task ProduceAsync(string key, T eventValue, CancellationToken cancellationToken)
    {
        var message = new Message<string, T>
        {
            Key = key,
            Value = eventValue
        };

        await _producer.ProduceAsync(_topic, message, cancellationToken);
    }
}
