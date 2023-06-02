namespace SOLID_Samples;

internal class Sample3
{
    public record Message
    {
        public string Sender { get; set; }
    }

    public class Notifier
    {
        public void SendMail(Message message)
        {
            //do something
        }

        public void SendSmsl(Message message)
        {
            //do something
        }

        public void SendWhatsApp(Message message)
        {
            //do something
        }

        public void SendSlack(Message message)
        {
            //do something
        }
    }
}