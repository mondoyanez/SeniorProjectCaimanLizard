namespace WatchParty.Services.Abstract;
public interface ITwilioService
{
    void SendReminder(string recipientNumber, string message);
}