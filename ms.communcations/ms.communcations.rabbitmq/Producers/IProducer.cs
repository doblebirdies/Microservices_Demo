using ms.communcations.rabbitmq.Events;

namespace ms.communcations.rabbitmq.Producers
{
    public interface IProducer
    {
        void Producer(IRabbitMqEvent rabbitmqEvent);
    }
}
