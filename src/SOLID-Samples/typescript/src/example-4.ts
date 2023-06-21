interface SmsMessage {
  sender: string;
}

class SysteminformationService {
  getLocalMachineData(): string {
    return 'PC-Name: Foo, Browser: Bar';
  }
}

class SmsService {
  send(number: string, message: string): void {
    // TODO: implement sms send
  }
}

class SmsNotifier {
  sendSms(message: SmsMessage): void {
    var localData = new SysteminformationService().getLocalMachineData();

    var smsService = new SmsService();
    smsService.send(message.Sender, `${localData} Kind regards co-IT.eu GmbH`);
  }
}
