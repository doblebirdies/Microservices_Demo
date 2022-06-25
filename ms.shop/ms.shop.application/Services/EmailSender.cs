namespace ms.shop.application.Services
{
    public class EmailSender : IEmailSender
    {
        public void SendOrderCanceledEmail(string email)
        {
            Console.WriteLine("Su pedido ha sido cancelado por falta de stock");
        }

        public void SendOrderPreparedEmail(string email)
        {
            Console.WriteLine("Su pedido está preparado y listo para enviar");
        }

        public void SendOrderShippedEMail(string email)
        {
            Console.WriteLine("Su pedido ha sido enviado y lo recibirá en los proximos días");
        }
    }
}
