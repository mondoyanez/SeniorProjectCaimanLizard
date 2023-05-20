using WatchParty.Services.Abstract;

namespace WatchParty.Services.Concrete;
public class TwilioService: ITwilioService
{
    private string? _accountSid;
    private string? _authToken;

    public TwilioService(string accountSid, string authToken)
    {
        _accountSid = accountSid;
        _authToken = authToken;
    }

    public void SendReminder(string recipientNumber, string message)
    {
        throw new NotImplementedException();
    }
}