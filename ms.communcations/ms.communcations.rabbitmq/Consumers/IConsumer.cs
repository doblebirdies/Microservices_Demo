namespace ms.communcations.rabbitmq.Consumers
{
    public interface IConsumer
    {
        void Subscribe();
        void Unsubscribe();
    }
}
