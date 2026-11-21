namespace Dathomir.Backoffice.Application.Providers.Events;

public interface IEventProducer<T> where T : class
{
    Task ProduceAsync(string key, T eventValue, CancellationToken cancellationToken);
}
