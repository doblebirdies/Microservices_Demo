namespace ms.communications.rabbitmq.Consumers
{
    public interface IConsumer
    {
        void Subscribe();
        void Unsubscribe();
    }
}
