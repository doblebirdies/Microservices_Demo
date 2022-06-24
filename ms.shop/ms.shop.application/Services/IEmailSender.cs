namespace ms.shop.application.Services
{
    public interface IEmailSender
    {
        void SendOrderCanceledEmail(string email);
        void SendOrderPreparedEmail(string email);
        void SendOrderShippedEMail(string email);
    }
}
