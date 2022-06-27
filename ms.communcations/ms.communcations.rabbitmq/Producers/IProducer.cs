using ms.communications.rabbitmq.Events;

namespace ms.communications.rabbitmq.Producers
{
    public interface IProducer
    {
        void SendMessage(IRabbitMqEvent rabbitmqEvent);
    }
}
