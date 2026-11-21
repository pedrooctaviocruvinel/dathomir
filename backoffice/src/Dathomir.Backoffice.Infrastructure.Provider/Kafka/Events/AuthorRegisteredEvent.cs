using Dathomir.Backoffice.Application.Providers.Events.AuthorRegisteredEvent;
using Microsoft.Extensions.Options;

namespace Dathomir.Backoffice.Infrastructure.Provider.Kafka.Events;

public class AuthorRegisteredEvent(IOptions<KafkaConfiguration> kafkaConfiguration) : EventProducer<AuthorRegisteredEventDTO>(kafkaConfiguration, "Authors"), IAuthorRegisteredEvent { }
