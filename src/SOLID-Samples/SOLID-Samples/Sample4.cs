namespace SOLID_Samples;

internal class Sample4
{
    public record Message
    {
        public string Sender { get; set; }
    }

    public class SysteminformationService
    {
        public string GetLocalMachineData()
        {
            return "PC-Name: Foo, Browser: Bar";
        }
    }

    public class SmsService
    {
        public void Send(string number, string message)
        {
            //send
        }
    }

    public class Notifier
    {
        public void SendSms(Message message)
        {
            var localData = new SysteminformationService().GetLocalMachineData();

            var smsService = new SmsService();
            smsService.Send(message.Sender, $"{localData} Kind regards co-IT.eu GmbH");
        }
    }
}