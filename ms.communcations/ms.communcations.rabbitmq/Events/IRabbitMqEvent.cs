namespace ms.communcations.rabbitmq.Events
{
    public interface IRabbitMqEvent
    {
        string Serialize();
    }
}
