using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WatchParty.Services.Abstract;

namespace WatchParty.Services.Concrete;
public class TwilioService: ITwilioService
{
    private readonly string? _accountSid;
    private readonly string? _authToken;

    public TwilioService(string accountSid, string authToken)
    {
        _accountSid = accountSid;
        _authToken = authToken;
    }

    public void SendReminder(string recipientNumber, string messageSent)
    {
        TwilioClient.Init(_accountSid, _authToken);

        var message = MessageResource.Create(
            new PhoneNumber(recipientNumber),
            from: new PhoneNumber("+18552385106"),
            body: messageSent
        );

        Console.WriteLine(message.Sid);
    }
}