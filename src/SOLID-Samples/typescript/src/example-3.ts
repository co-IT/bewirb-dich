interface SmsMessage {
  Sender: string;
}

class Notifier {
  sendMail(message: SmsMessage) {
    //do something
  }

  sendSmsl(message: SmsMessage) {
    //do something
  }

  sendWhatsApp(message: SmsMessage) {
    //do something
  }

  sendSlack(message: SmsMessage) {
    //do something
  }
}
